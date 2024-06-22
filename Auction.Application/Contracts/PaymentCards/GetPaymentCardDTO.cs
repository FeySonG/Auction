namespace Auction.Application.Contracts.PaymentCards;

/// <summary>
/// DTO for retrieving a payment card.
/// </summary>
public class GetPaymentCardDTO
{
    /// <summary>
    /// Gets or sets the card number.
    /// </summary>
    public string CardNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the expiry date.
    /// </summary>
    public string ExpiryDate { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the card type.
    /// </summary>
    public PaymentCardType CardType { get; set; }
}
