using Auction.Domain.Enums.UserEnums;
using Auction.Domain.Models.PaymentCards;
using Auction.Domain.Models.UserContacts;

namespace Auction.Application.Contracts.Users
{
    public class UserCreateDto
    {
        public required string NickName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PasswordConfirm { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
