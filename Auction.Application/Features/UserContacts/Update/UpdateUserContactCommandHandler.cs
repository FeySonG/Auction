using Auction.Application.Abstractions;
using Auction.Application.Contracts.UserContacts;
using Auction.Application.Services;
using Auction.Domain.Models.UserContacts;
using Auction.Domain.Result;
using Mapster;

namespace Auction.Application.Features.UserContacts.Update;

internal class UpdateUserContactCommandHandler<TValue>(
    IUserContactRepository userContactRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateUserContactCommand, Result<UserContactUpdateDTO>>
{
    public async Task<Result<UserContactUpdateDTO>> Handle(UpdateUserContactCommand request, CancellationToken cancellationToken)
    {
        UserContact? Usercontact = await userContactRepository.GetByUserIdAsync(request.ContactDTO.UserId);

        if (Usercontact == null)
            return new Error("UserContact.IdNotFound", "attempt to update a non-existent user contact");
        Usercontact = request.ContactDTO.Adapt<UserContact>();
        userContactRepository.Update(Usercontact);

        await unitOfWork.SaveChangesAsync();

        return request.ContactDTO;
    }

}
