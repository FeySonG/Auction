using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Modules.PaymentCards
{
    public class PaymentCardRepository : IPaymentCardRepository
    {
        public void Add(PaymentCard entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentCard>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentCard?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Remove(PaymentCard entity)
        {
            throw new NotImplementedException();
        }

        public void Update(PaymentCard entity)
        {
            throw new NotImplementedException();
        }
    }
}
