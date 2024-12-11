namespace Auction.Application.Features.PaymentCards.Create;

public record CreatePaymentCardCommand(CreatePaymentCardDTO CardDTO, int UserId) : ICommand<Result<bool>>;
