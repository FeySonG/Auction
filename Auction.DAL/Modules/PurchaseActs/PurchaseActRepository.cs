using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Modules.PurchaseActs
{
    public class PurchaseActRepository : IPurchaseActRepository
    {
        public void Add(PurchaseAct entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseAct>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseAct?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Remove(PurchaseAct entity)
        {
            throw new NotImplementedException();
        }

        public void Update(PurchaseAct entity)
        {
            throw new NotImplementedException();
        }
    }
}
