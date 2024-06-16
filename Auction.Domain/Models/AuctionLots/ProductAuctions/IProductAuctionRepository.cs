namespace Auction.Domain.Models.AuctionLots.ProductAuctions;

public interface IProductAuctionRepository : IRepository<ProductAuction>
{
    Task<List<ProductAuction>> GetAllInqlude();
    Task<ProductAuction?> GetById(long id);
}