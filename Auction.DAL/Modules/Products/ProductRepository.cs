using Auction.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Modules.Products
{
    public class ProductRepository(AppDbContext dbContext) : Repository<User>(dbContext), IProductRepository
    {
       
    }
}
