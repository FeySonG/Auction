using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Modules.AuctionLots.ServiceAuctions
{
    public class ServiceAuctionRepository : IServiceAuctionRepository
    {
        public void Add(ServiceAuction entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceAuction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceAuction?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ServiceAuction entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ServiceAuction entity)
        {
            throw new NotImplementedException();
        }
    }
}
