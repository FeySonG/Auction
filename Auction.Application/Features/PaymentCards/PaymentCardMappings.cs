namespace Auction.Application.Features.PaymentCards
{
    /// <summary>
    /// Class for configuring mapping between payment card entities and their DTOs.
    /// </summary>
    public class PaymentCardMappings : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentCardMappings"/> class.
        /// </summary>
        public PaymentCardMappings()
        {
            // Configure mapping from PaymentCard entity to CreatePaymentCardDTO and vice versa.
            CreateMap<PaymentCard, CreatePaymentCardDTO>().ReverseMap();
        }
    }
}
