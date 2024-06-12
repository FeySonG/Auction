namespace Auction.Application.Contracts.PaymentCards
{
    public class PaymentCardUpdateDTO
    {

        [Required]
        [StringLength(16)]
        public string CardNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(5)]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Введите дату в формате MM/YY")]
        [DisplayFormat(DataFormatString = "{0:MM/yy}", ApplyFormatInEditMode = true)]
        public string ExpiryDate { get; set; } = string.Empty;

        [Required]
        [StringLength(3)]
        public string CVV { get; set; } = string.Empty;

        public PaymentCardType CardType { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; } = 0;

    }
}
