namespace Auction.Application.Features.PaymentCards.Create;

/// <summary>
/// Command to create a payment card.
/// </summary>
public record CreatePaymentCardCommand(CreatePaymentCardDTO CardDTO, int UserId) : ICommand<Result<bool>>;
