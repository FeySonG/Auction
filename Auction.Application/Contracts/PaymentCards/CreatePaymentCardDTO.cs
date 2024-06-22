namespace Auction.Application.Contracts.PaymentCards;

/// <summary>
/// DTO for creating a payment card.
/// </summary>
public class CreatePaymentCardDTO
{
    /// <summary>
    /// Gets or sets the card number.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(16, ErrorMessage = Message.MAX_LENGTH)]
    [MinLength(16, ErrorMessage = Message.MIN_LENGTH)]
    [RegularExpression("^[0-9]*$", ErrorMessage = Message.ONLY_DIGITAL)]
    public required string CardNumber { get; set; }

    /// <summary>
    /// Gets or sets the expiry date.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(5, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = Message.EXPIRY_DATE)]
    [DisplayFormat(DataFormatString = "{0:MM/yy}", ApplyFormatInEditMode = true)]
    public required string ExpiryDate { get; set; }

    /// <summary>
    /// Gets or sets the CVV.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(3, ErrorMessage = Message.MAX_LENGTH)]
    [MinLength(3, ErrorMessage = Message.MIN_LENGTH)]
    [RegularExpression("^[0-9]*$", ErrorMessage = Message.ONLY_DIGITAL)]
    public required string CVV { get; set; }

    /// <summary>
    /// Gets or sets the card type.
    /// </summary>
    [Required(ErrorMessage = Message.REQUIRED)]
    [EnumDataType(typeof(PaymentCardType))]
    public required PaymentCardType CardType { get; set; }
}
