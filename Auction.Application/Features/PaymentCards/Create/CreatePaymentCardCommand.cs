using Auction.Application.Abstractions;
using Auction.Application.Contracts.PaymentCards;
using Auction.Domain.Result;

namespace Auction.Application.Features.PaymentCards.Create
{
    public record CreatePaymentCardCommand(PaymentCardCreateDTO CardDTO, int UserId) : ICommand<Result<bool>>;

}
