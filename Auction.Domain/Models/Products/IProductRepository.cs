namespace Auction.Domain.Models.Products;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetByName(string Name);
    Task<Product?> GetById(long Id);
    Task<List<Product?>> GetUserProducts(long Id);
}