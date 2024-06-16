namespace Auction.Application.Features.Users.UpdateRole;

public record UpdateUserRoleCommand(UserRole role, long userId) : ICommand<Result<bool>>;