namespace Auction.Application.Contracts.PaymentCards;

public class GetPaymentCardDTO
{

    public string CardNumber { get; set; } = string.Empty;

    public string ExpiryDate { get; set; } = string.Empty;

    public PaymentCardType CardType { get; set; }

}
