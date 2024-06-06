using Auction.Application.Abstractions;
using Auction.Domain.Models.Users;
using Auction.Domain.Result;

namespace Auction.Application.Features.Users.UpdateRole
{
    public record UpdateUserRoleCommand(UserRole role, long userId) : ICommand<Result<bool>>;

}
