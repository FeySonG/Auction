namespace Auction.Domain.Models.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserById(long id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<string?> CheckUniqueNickNameAsync(string nickName);
    Task<string?> CheckUniqueEmailAsync(string email);
}