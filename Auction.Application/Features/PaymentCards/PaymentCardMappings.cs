namespace Auction.Application.Features.PaymentCards
{
    public class PaymentCardMappings : Profile
    {
        public PaymentCardMappings()
        {
            CreateMap<PaymentCard, PaymentCardCreateDTO>().ReverseMap();
            CreateMap<PaymentCard, PaymentCardUpdateDTO>().ReverseMap();
        }
    }
}
