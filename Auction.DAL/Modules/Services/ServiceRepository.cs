using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Modules.Services
{
    public class ServiceRepository : IServiceRepository
    {
        public void Add(Service entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Service>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Service?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Service entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Service entity)
        {
            throw new NotImplementedException();
        }
    }
}
