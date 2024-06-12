namespace Auction.DAL.Services
{
    public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
    }
}
