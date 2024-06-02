using Auction.Domain.Abstractions;
using Auction.Domain.Models.PaymentCards;
using Auction.Domain.Models.Products;
using Auction.Domain.Models.UserContacts;


namespace Auction.Domain.Models.Users
{
    public class User : Entity
    {
        public required string NickName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public PaymentCard? BankCard { get; set; }
        public UserContact? Contact { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}
