using Auction.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.Models.PaymentCards
{
    public class PaymentCard : Entity
    {
        public required long UserId { get; set; }

        [StringLength(16)]
        public required string CardNumber { get; set; }

        public required DateTime ExpiryDate { get; set; }

        [StringLength(3)]
        public required string CVV { get; set; }

        public PaymentCardType CardType { get; set; }

        public decimal Balance { get; set; } = 0;

    }
}
