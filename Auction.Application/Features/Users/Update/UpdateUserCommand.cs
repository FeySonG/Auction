using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using Auction.Domain.Result;

namespace Auction.Application.Features.Users.Update
{
    public record UpdateUserCommand(UserUpdateDTO UserDTO, int UserID) : ICommand<Result<bool>>;
}
