namespace Auction.Application.Features.PaymentCards.Delete;

public record DeletePaymentCardCommand(int UserId) : ICommand<Result<bool>>;
