using Auction.Application.Abstractions;
using Auction.Application.Services;
using Auction.Domain.Models.UserContacts;
using Auction.Domain.Result;
using Mapster;

namespace Auction.Application.Features.UserContacts.Create
{
    public class CreateUserContactCommandHandler(IUserContactRepository repository, IUnitOfWork uow) : ICommandHandler<CreateUserContactCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(CreateUserContactCommand request, CancellationToken cancellationToken)
        {
            if (repository.CheckExistToCreate(request.UserId))
                return new Error(ContactErrorCodes.AlreadyExist, ContactErrorMessages.Existent);

            UserContact contact = request.ContactDTO.Adapt<UserContact>();
            contact.UserId = request.UserId;

            repository.Add(contact);
            await uow.SaveChangesAsync();

            return true;
        }
    }
}
