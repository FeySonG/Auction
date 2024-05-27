using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Abstractions
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(long id);
    }
}
