namespace Auction.Application.Features.UserContacts.Create;

public record CreateUserContactCommand(CreateUserContactDTO ContactDTO, int UserId) : ICommand<Result<bool>>;