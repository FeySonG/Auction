namespace Auction.DAL.Modules.AuctionLots.ProductAuctions;

public class ProductAuctionRepository(AppDbContext dbContext) : Repository<ProductAuction>(dbContext), IProductAuctionRepository
{
    public async Task<List<ProductAuction>> GetAllInqlude() => 
        await DbContext.ProductAuctions.Include(p => p.Product).ToListAsync();
    public async Task<ProductAuction?> GetById(long id) =>  
        await DbContext.ProductAuctions.Include(p => p.Product).FirstOrDefaultAsync(a => a.Id == id);
	public async Task<List<ProductAuction>> GetUserAuctions(long userId) => 
        await DbContext.ProductAuctions.Include(p => p.Product).Where(p => p.SallerId == userId).ToListAsync();
	
}