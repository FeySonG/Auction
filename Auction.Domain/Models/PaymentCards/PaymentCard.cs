using Auction.Domain.Abstractions;

namespace Auction.Domain.Models.PaymentCards
{
    public class PaymentCard : Entity
    {
        public required long UserId { get; set; }
        public required long CardNumber { get; set; }
        public required DateTime ExpiryDate { get; set; }
        public required string CVV { get; set; }
        public string? CardType { get; set; }
        public decimal Balance { get; set; } = 0;

    }
}
