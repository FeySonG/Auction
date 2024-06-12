namespace Auction.Application.Features.PaymentCards.Update
{
    public record UpdatePaymentCardCommand(PaymentCardUpdateDTO PaymentCardDTO, int UserId) : ICommand<Result<bool>>;
}
