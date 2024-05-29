using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using MediatR;

namespace Auction.Application.Features.Users.GetAll
{
    public class GetAllUsersQuery : IQuery<List<UserResponseDto>>;
}
