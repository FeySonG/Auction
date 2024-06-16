namespace Auction.Application.Features.PaymentCards.Update;

public record UpdatePaymentCardCommand(UpdatePaymentCardDTO PaymentCardDTO, int UserId) : ICommand<Result<bool>>;
