using Auction.Domain.Abstractions;
using Auction.Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models.Services
{
    public interface IServiceLayerRepository : IRepository<ServiceLayer>
    {
        Task<ServiceLayer?> GetByName(string Name);
        Task<List<ServiceLayer?>> GetUserService(long Id);
    }
}
