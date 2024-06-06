using Auction.Domain.Models.PaymentCards;
using System.ComponentModel.DataAnnotations;

namespace Auction.Application.Contracts.PaymentCards
{
    public class PaymentCardCreateDTO
    {

        [Required]
        [StringLength(16)]
        public string CardNumber { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [StringLength(3)]
        public string CVV { get; set; } = string.Empty;

        [Required]
        public PaymentCardType CardType { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; } = 0;
    }
}
