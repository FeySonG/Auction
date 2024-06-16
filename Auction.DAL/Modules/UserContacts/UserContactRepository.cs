namespace Auction.DAL.Modules.UserContacts;

public class UserContactRepository(AppDbContext dbContext) : IUserContactRepository 
{
    public async Task<UserContact?> GetByUserIdAsync(long id) => await dbContext.UserContacts.FirstOrDefaultAsync(c => c.UserId == id);

    public bool CheckExistToCreate(int userId)
    {
        if (dbContext.UserContacts.Any(c => c.UserId == userId))
            return true;
        return false;
    }

    public void Add(UserContact contact) => dbContext.UserContacts.Add(contact);

    public async Task<List<UserContact>> GetAllAsync() => await dbContext.UserContacts.ToListAsync();

    public async Task<UserContact?> GetByIdAsync(long id) => await dbContext.UserContacts.FirstAsync(c => c.Id == id);
 
    public  void Remove(UserContact contact) => dbContext.Remove(contact);

    public void Update(UserContact contact) => dbContext.Update(contact);

}