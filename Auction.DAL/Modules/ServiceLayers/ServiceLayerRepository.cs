namespace Auction.DAL.Modules.ServiceLayers;

public class ServiceLayerRepository(AppDbContext dbContext) : Repository<ServiceLayer>(dbContext), IServiceLayerRepository
{
    public Task<ServiceLayer?> GetById(long Id) => DbContext.ServiceLayers.FirstOrDefaultAsync(s => s.Id == Id);
    public Task<List<ServiceLayer>> GetByName(string serviceName) => DbContext.ServiceLayers.Where(p => p.ServiceName == serviceName).ToListAsync();
    public async Task<List<ServiceLayer?>> GetUserService(long userId)
    {
        var services = await DbContext.ServiceLayers.Where(p => p.UserId == userId).ToListAsync();
        return services.Cast<ServiceLayer?>().Where(p => p != null).ToList();
    }
}