using System.ComponentModel.DataAnnotations;

namespace Auction.Application.Contracts.UserContacts
{
    public class UserContactUpdateDTO
    {
        public long UserId { get; set; } = 0;

        [StringLength(150)]
        public string? Email { get; set; } = "string";

        [StringLength(100)]
        public required string PhoneNumber { get; set; } = "string";

        [StringLength(100)]
        public string? Telegram { get; set; } = "string";

        [StringLength(100)]
        public string? Instagram { get; set; } = "string";

        [StringLength(100)]
        public string? City { get; set; } = "string";

        [StringLength(100)]
        public string? Country { get; set; } = "string";
    }
}