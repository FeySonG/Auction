using Auction.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models.PaymentCards
{
    public interface IPaymentCardRepository : IRepository<PaymentCard>
    {
    }
}
