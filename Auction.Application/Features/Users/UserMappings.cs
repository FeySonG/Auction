using Auction.Application.Contracts.PaymentCards;
using Auction.Application.Contracts.UserContacts;
using Auction.Application.Contracts.Users;
using Auction.Domain.Models.PaymentCards;
using Auction.Domain.Models.UserContacts;
using Auction.Domain.Models.Users;
using AutoMapper;

namespace Auction.Application.Features.Users
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            CreateMap<User, UserGetProfileDTO>()
            .ForMember(dest => dest.BankCard, opt => opt.MapFrom(src => src.BankCard))
            .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
            .ReverseMap()
            .ForMember(dest => dest.BankCard, opt => opt.MapFrom(src => src.BankCard))
            .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact));


            CreateMap<UserContact, UserContactGetDTO>();
            CreateMap<PaymentCard, PaymentCardGetDTO>();

        }
    }
}
