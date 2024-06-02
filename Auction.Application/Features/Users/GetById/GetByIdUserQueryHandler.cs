using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using Auction.Domain.Models.Result;
using Auction.Domain.Models.Users;
using AutoMapper;
using MediatR;

namespace Auction.Application.Features.Users.GetById
{
    public class GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        : IQueryHandler<GetByIdUserQuery, UserResponseDto>
    {
        public async Task<UserResponseDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserById(request.Id);
            if (user == null) return null!;
            return mapper.Map<UserResponseDto>(user);
        }
    }
}
