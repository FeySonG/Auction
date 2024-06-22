namespace Auction.Application.Contracts.PaymentCards;

public class CreatePaymentCardDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(16, ErrorMessage = Message.MAX_LENGTH)]
    [MinLength(16, ErrorMessage = Message.MIN_LENGTH)]
    [RegularExpression("^[0-9]*$", ErrorMessage = Message.ONLY_DIGITAL)]
    public required string CardNumber { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(5, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = Message.EXPIRY_DATE)]
    [DisplayFormat(DataFormatString = "{0:MM/yy}", ApplyFormatInEditMode = true)]
    public required string ExpiryDate { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(3, ErrorMessage = Message.MAX_LENGTH)]
    [MinLength(3, ErrorMessage = Message.MIN_LENGTH)]
    [RegularExpression("^[0-9]*$", ErrorMessage = Message.ONLY_DIGITAL)]
    public required string CVV { get; set; }

    [Required(ErrorMessage = Message.REQUIRED)]
    [EnumDataType(typeof(PaymentCardType))]
    public required PaymentCardType CardType { get; set; }
}
