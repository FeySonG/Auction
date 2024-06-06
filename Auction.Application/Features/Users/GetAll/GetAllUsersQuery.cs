using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using Auction.Domain.Result;
using MediatR;

namespace Auction.Application.Features.Users.GetAll
{
    public class GetAllUsersQuery : IQuery<Result<List<UserResponseDTO>>>;
}
