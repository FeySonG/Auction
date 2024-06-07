using Auction.Application.Abstractions;
using Auction.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.PaymentCards.Delete
{
    public record DeletePaymentCardCommand(int UserId) : ICommand<Result<bool>>;
}
