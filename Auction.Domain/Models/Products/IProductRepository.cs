using Auction.Domain.Abstractions;
using Auction.Domain.Models.Users;

namespace Auction.Domain.Models.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetByName(string Name);
        Task<List<Product?>> GetUserProducts(long Id);
    }
}
