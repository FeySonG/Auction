using Auction.DAL.Services;
using Auction.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Modules.Products
{
    public class ProductRepository(AppDbContext dbContext) : Repository<User>(dbContext), IProductRepository
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        Task<List<Product>> IReadRepository<Product>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Product?> IReadRepository<Product>.GetByUserIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
