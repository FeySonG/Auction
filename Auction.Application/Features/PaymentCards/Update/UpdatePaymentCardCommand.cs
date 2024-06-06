using Auction.Application.Abstractions;
using Auction.Application.Contracts.PaymentCards;
using Auction.Domain.Result;

namespace Auction.Application.Features.PaymentCards.Update
{
    public record UpdatePaymentCardCommand(PaymentCardUpdateDTO PaymentCardDTO, int UserId) : ICommand<Result<bool>>;
}
