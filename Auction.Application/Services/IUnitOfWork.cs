namespace Auction.Application.Services;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}