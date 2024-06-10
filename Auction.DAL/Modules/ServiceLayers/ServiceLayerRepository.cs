using Auction.DAL.Services;
using Auction.Domain.Models.Services;

namespace Auction.DAL.Modules.Services
{
    public class ServiceLayerRepository(AppDbContext dbContext) : Repository<ServiceLayer>(dbContext), IServiceLayerRepository
    {

        public Task<ServiceLayer?> GetByName(string ServiceName) => DbContext.Services.FirstOrDefaultAsync(u => u.ServiceName == ServiceName);
        public async Task<List<ServiceLayer?>> GetUserService(long userId)
        {
            var services = await DbContext.Services.Where(p => p.UserId == userId).ToListAsync();
            return services.Cast<ServiceLayer?>().Where(p => p != null).ToList();
        }
    }
}
