using Auction.Application.Abstractions;
using Auction.Application.Services;
using Auction.Domain.Models.Result;
using Auction.Domain.Models.UserContacts;
using Mapster;

namespace Auction.Application.Features.UserContacts.Update
{
    internal class UpdateUserContactCommandHandler<TValue>(IUserContactRepository userContactRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserContactCommand, Result>
    {
        public async Task<Result> Handle(UpdateUserContactCommand request, CancellationToken cancellationToken)
        {
            UserContact? Usercontact = await userContactRepository.GetByUserIdAsync(request.contactDTO.UserId);

            if (Usercontact == null)
                return Result.Fail<bool>("UserContact.IdNotFound", "attempt to update a non-existent user contact");

            Usercontact = request.contactDTO.Adapt<UserContact>();
            userContactRepository.Update(Usercontact);

            await unitOfWork.SaveChangesAsync();

            return Result.Ok(Usercontact);
        }

    }
}
