using Auction.DAL.Services;
using Auction.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Modules.Products
{
    public class ProductRepository(AppDbContext dbContext) : Repository<Product>(dbContext), IProductRepository
    {
        public Task<Product?> GetByName(string ProductName) => DbContext.Products.FirstOrDefaultAsync(u => u.ProductName == ProductName);

        public async Task<List<Product?>> GetUserProducts(long userId)
        {
            var products = await DbContext.Products.Where(p => p.UserId == userId).ToListAsync();
            return products.Cast<Product?>().Where(p => p != null).ToList();
        }
    }
}
