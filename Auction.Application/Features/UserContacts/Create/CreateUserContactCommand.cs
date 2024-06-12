namespace Auction.Application.Features.UserContacts.Create
{
    public record CreateUserContactCommand(UserContactCreateDTO ContactDTO, int UserId) : ICommand<Result<bool>>;
}
