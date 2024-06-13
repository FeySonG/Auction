using Auction.Domain.Abstractions;

namespace Auction.Domain.Models.ServiceLayers
{
    public interface IServiceLayerRepository : IRepository<ServiceLayer>
    {
        Task<List<ServiceLayer>> GetByName(string Name);
        Task<ServiceLayer?> GetById(long Id);
        Task<List<ServiceLayer?>> GetUserService(long Id);
    }
}
