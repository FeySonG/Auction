using Auction.Application.Contracts.Users;
using Auction.Domain.Models.Users;
using AutoMapper;

namespace Auction.Application.Features.Users
{
    public class PaymentCardMappings : Profile
    {
        public PaymentCardMappings()
        {
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
        }
    }
}
