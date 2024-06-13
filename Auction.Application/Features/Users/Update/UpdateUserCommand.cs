namespace Auction.Application.Features.Users.Update
{
    public record UpdateUserCommand(UserUpdateDTO UserDTO, int UserID) : ICommand<Result<bool>>;
}
