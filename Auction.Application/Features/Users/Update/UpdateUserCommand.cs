namespace Auction.Application.Features.Users.Update;

public record UpdateUserCommand(UpdateUserDTO UserDTO, int UserID) : ICommand<Result<bool>>;