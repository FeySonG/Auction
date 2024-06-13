namespace Auction.DAL.Services
{
    public abstract class Repository<TEntity>(AppDbContext DbContext) : IRepository<TEntity> where TEntity : Entity
    {
        protected AppDbContext DbContext = DbContext;

        public void Add(TEntity entity) => DbContext.Add(entity);

        public Task<List<TEntity>> GetAllAsync() => DbContext
            .Set<TEntity>()
            .ToListAsync();

        public Task<TEntity?> GetByUserIdAsync(long id) => DbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(entity => entity.Id == id);

        public void Remove(TEntity entity) => DbContext
            .Set<TEntity>()
            .Remove(entity);

        public void Update(TEntity entity) => DbContext
            .Set<TEntity>()
            .Update(entity);
    }
}
