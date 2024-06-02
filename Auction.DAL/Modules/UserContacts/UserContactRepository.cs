using Auction.DAL.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Modules.UserContacts
{
    public class UserContactRepository(AppDbContext dbContext) : IUserContactRepository 
    {
        public async Task<UserContact?> GetByUserIdAsync(long id)
        {
            var contact = await dbContext.UserContacts.FirstOrDefaultAsync(c => c.UserId == id);
            return contact;
        }

        public void Add(UserContact entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserContact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserContact?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Remove(UserContact entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UserContact entity)
        {
            throw new NotImplementedException();
        }
    }
}
