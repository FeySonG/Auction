using Auction.Domain.Models.PaymentCards;
using Auction.Domain.Models.UserContacts;
using Auction.Domain.Models.Users;

namespace Auction.Application.Contracts.Users
{
    public class UserUpdateDTO
    {
        public required string NickName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}
