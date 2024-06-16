namespace Auction.Application.Features.Users;

public class PaymentCardMappings : Profile
{
    public PaymentCardMappings()
    {
        CreateMap<User, GetUserDTO>().ReverseMap();
        CreateMap<User, CreateUserDTO>().ReverseMap();
        CreateMap<User, UpdateUserDTO>().ReverseMap();

        CreateMap<User, GetUserProfileDTO>()
       .ForMember(dest => dest.BankCard, opt => opt.MapFrom(src => src.BankCard))
       .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
       .ReverseMap()
       .ForMember(dest => dest.BankCard, opt => opt.MapFrom(src => src.BankCard))
       .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact));


        CreateMap<UserContact, GetUserContactDTO>();
        CreateMap<PaymentCard, GetPaymentCardDTO>();
    }
}