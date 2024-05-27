using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Modules.AuctionLots.ProductAuctions
{
    public class ProductAuctionRepository : IProductAuctionRepository
    {
        public void Add(ProductAuction entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductAuction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductAuction?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductAuction entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductAuction entity)
        {
            throw new NotImplementedException();
        }
    }
}
