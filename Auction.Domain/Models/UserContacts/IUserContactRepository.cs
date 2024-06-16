namespace Auction.Domain.Models.UserContacts;

public interface IUserContactRepository : IRepository<UserContact>
{
    public bool CheckExistToCreate(int userId);
}