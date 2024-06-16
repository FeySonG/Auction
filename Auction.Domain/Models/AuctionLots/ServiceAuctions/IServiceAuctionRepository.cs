namespace Auction.Domain.Models.AuctionLots.ServiceAuctions;

public interface IServiceAuctionRepository : IRepository<ServiceAuction>
{
    Task<List<ServiceAuction>> GetAllInqlude();
    Task<ServiceAuction?> GetById(long id);
}