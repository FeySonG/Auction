using Auction.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Modules.AuctionLots.ProductAuctions
{
    public class ProductAuctionRepository(AppDbContext dbContext) : Repository<ProductAuction>(dbContext), IProductAuctionRepository
    {
        public async Task<List<ProductAuction>> GetAllInqlude() => 
            await DbContext.ProductAuctions.Include(p => p.Product).ToListAsync();
        public async Task<ProductAuction?> GetById(long id) =>  
            await DbContext.ProductAuctions.Include(p => p.Product).FirstOrDefaultAsync(a => a.Id == id);
    }
}
