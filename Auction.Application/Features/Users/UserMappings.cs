namespace Auction.Application.Features.Users
{
    public class PaymentCardMappings : Profile
    {
        public PaymentCardMappings()
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
