using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using Auction.Domain.Models.Users;
using Auction.Domain.Result;
using AutoMapper;

namespace Auction.Application.Features.Users.GetAll
{
    public class GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper) 
        : IQueryHandler<GetAllUsersQuery, Result<List<UserResponseDTO>>>
    {
        public async Task<Result<List<UserResponseDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();
            if (users.Count == 0)
                return new Error(UserErrorCodes.NoContent, "");

            return mapper.Map<List<UserResponseDTO>>(users);
        }
    }
}
