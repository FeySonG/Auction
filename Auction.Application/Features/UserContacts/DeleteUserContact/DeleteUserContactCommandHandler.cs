namespace Auction.Application.Features.UserContacts.DeleteUserContact;

internal class DeleteUserContactCommandHandler(IUserContactRepository repository, IUnitOfWork uow) : ICommandHandler<DeleteUserContactCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteUserContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await repository.GetByUserIdAsync(request.UserId);
        if (contact == null)
            return new Error(ContactErrorCodes.IdNotFound, ContactErrorCodes.IdNotFound);

        repository.Remove(contact);
        await uow.SaveChangesAsync();
        return true;
    }
}