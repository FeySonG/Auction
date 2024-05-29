using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using Auction.Domain.Models.Users;
using AutoMapper;
using MediatR;

namespace Auction.Application.Features.Users.GetAll
{
    public class GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper) 
        : IQueryHandler<GetAllUsersQuery, List<UserResponseDto>>
    {
        public async Task<List<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();

            return mapper.Map<List<UserResponseDto>>(users);
        }
    }
}
