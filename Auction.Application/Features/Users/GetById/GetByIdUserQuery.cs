using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using Auction.Domain.Result;

namespace Auction.Application.Features.Users.GetById
{
    public record GetByIdUserQuery(long Id) : IQuery<Result<UserResponseDTO>>;

}
