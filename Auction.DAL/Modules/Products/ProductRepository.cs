namespace Auction.DAL.Modules.Products;

public class ProductRepository(AppDbContext dbContext) : Repository<Product>(dbContext), IProductRepository
{
    public Task<Product?> GetById(long Id) => DbContext.Products.FirstOrDefaultAsync(p => p.Id == Id);
    public async Task<List<Product>> GetByName(string productName) => await DbContext.Products.Where(p => p.ProductName == productName).ToListAsync();
    public async Task<List<Product?>> GetUserProducts(long userId)
    {
        var products = await DbContext.Products.Where(p => p.UserId == userId).ToListAsync();
        return products.Cast<Product?>().Where(p => p != null).ToList();
    }
    public async Task<List<Product?>> GetUserOwnedProducts(long ownerId)
    {
        var products = await DbContext.Products.Where(p => p.OwnerId == ownerId).ToListAsync();
        return products.Cast<Product?>().Where(p => p != null).ToList();
    }
}