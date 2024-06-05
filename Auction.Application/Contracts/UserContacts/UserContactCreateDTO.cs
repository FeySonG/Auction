using System.ComponentModel.DataAnnotations;

namespace Auction.Application.Contracts.UserContacts
{
    public class UserContactCreateDTO
    {

        [StringLength(100)]
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        public string? Telegram { get; set; }

        [StringLength(100)]
        public string? Instagram { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }
    }
}
