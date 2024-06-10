using System.ComponentModel.DataAnnotations;

namespace Auction.Application.Contracts.Users
{
    public class UserLoginDTO
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
