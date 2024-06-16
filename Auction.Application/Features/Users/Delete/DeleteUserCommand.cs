namespace Auction.Application.Features.Users.Delete;

public record DeleteUserCommand(long id) : ICommand<Result<bool>>;