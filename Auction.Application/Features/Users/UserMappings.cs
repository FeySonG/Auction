using Auction.Application.Contracts.Users;
using Auction.Domain.Models.Users;
using AutoMapper;

namespace Auction.Application.Features.Users
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserResponseDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
        }
    }
}
