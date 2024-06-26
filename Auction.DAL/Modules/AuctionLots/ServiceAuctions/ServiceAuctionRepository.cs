﻿namespace Auction.DAL.Modules.AuctionLots.ServiceAuctions;

public class ServiceAuctionRepository(AppDbContext dbContext) : Repository<ServiceAuction>(dbContext), IServiceAuctionRepository
{
    public async Task<List<ServiceAuction>> GetAllInqlude() =>
        await DbContext.ServiceAuctions.Include(p => p.Service).ToListAsync();
    public async Task<ServiceAuction?> GetById(long id) =>
        await DbContext.ServiceAuctions.Include(p => p.Service).FirstOrDefaultAsync(a => a.Id == id);
}