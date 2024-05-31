
using Auction.Application.Abstractions;
using Auction.Domain.Models.Users;

namespace Auction.Application.Features.Users.Auth.Login
{
    public record LoginUserQuery(string email, string password) : IQuery<User?>;

}
