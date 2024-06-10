using Auction.Application.Contracts.PaymentCards;
using Auction.Application.Contracts.UserContacts;

namespace Auction.Application.Contracts.Users
{
    public class UserGetProfileDTO
    {
        public  string NickName { get; set; } = string.Empty;
        public  string FirstName { get; set; } = string.Empty;
        public  string LastName { get; set; } = string.Empty;
        public  string Email { get; set; } = string.Empty;
        public UserContactGetDTO? Contact { get; set; }
        public PaymentCardGetDTO? BankCard { get; set; }
    }
}
