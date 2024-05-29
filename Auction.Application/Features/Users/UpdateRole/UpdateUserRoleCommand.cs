using Auction.Application.Abstractions;
using Auction.Domain.Enums.UserEnums;

namespace Auction.Application.Features.Users.UpdateRole
{
    public record UpdateUserRoleCommand(UserRole role, long userId) : ICommand<bool>;

}
