using Auction.DAL.Services;
using Microsoft.EntityFrameworkCore;

namespace Auction.DAL.Modules.Users
{
    public class UserRepository(AppDbContext dbContext) : Repository<User>(dbContext), IUserRepository
    {
        public async Task<User?> GetUserById(long Id) => await DbContext.Users.FirstOrDefaultAsync(u => u.Id == Id);

    }
}
