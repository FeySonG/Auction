namespace Auction.Application.Features.PaymentCards.Create
{
    public record CreatePaymentCardCommand(PaymentCardCreateDTO CardDTO, int UserId) : ICommand<Result<bool>>;

}
