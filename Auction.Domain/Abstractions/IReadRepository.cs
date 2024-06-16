namespace Auction.Domain.Abstractions;

public interface IReadRepository<TEntity> where TEntity : Entity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByUserIdAsync(long id);
}