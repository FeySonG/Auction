using Auction.Application.Contracts.PaymentCards;
using Auction.Domain.Models.PaymentCards;
using AutoMapper;

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
