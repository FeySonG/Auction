namespace Auction.Application.Features.UserContacts.Create;

internal class CreateUserContactCommandHandler(IUserContactRepository repository, IUnitOfWork uow) : ICommandHandler<CreateUserContactCommand, Result<bool>>
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