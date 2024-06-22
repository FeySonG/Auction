namespace Auction.Application.Features.PaymentCards.Delete;

/// <summary>
/// Command to delete a payment card.
/// </summary>
public record DeletePaymentCardCommand(int UserId) : ICommand<Result<bool>>;
