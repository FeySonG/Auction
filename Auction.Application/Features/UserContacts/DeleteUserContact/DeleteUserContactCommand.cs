namespace Auction.Application.Features.UserContacts.DeleteUserContact;

public record DeleteUserContactCommand(long UserId) : ICommand<Result<bool>>;
