using Auction.Application.Abstractions;
using Auction.Domain.Models.Users;

namespace Auction.Application.Features.Users.UpdateRole
{
    public record UpdateUserRoleCommand(UserRole role, long userId) : ICommand<bool>;

}
