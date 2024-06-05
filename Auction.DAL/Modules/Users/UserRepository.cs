using Auction.DAL.Services;
using Microsoft.EntityFrameworkCore;

namespace Auction.DAL.Modules.Users
{
    public class UserRepository(AppDbContext dbContext) : Repository<User>(dbContext), IUserRepository
    {
        public async Task<string?> CheckUniqueEmailAsync(string email)
        {
            var response = await DbContext.Users.AnyAsync(u => u.Email == email);
            if(response == true) return email;   
            return null;
        }

        public async Task<string?> CheckUniqueNickNameAsync(string nickName)
        {
            var response = await DbContext.Users.AnyAsync(u => u.NickName == nickName);
            if (response == true) return nickName;
            return null;
        }

        public Task<User?> GetUserByEmailAsync(string email) => DbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User?> GetUserById(long Id) => await DbContext.Users.Include(u => u.Contact).FirstOrDefaultAsync(u => u.Id == Id);

    }
}
