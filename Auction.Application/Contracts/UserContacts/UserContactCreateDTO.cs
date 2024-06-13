namespace Auction.Application.Contracts.UserContacts
{
    public class UserContactCreateDTO
    {
        [StringLength(100)]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(100)]
        [Required]
        public string Telegram { get; set; } = string.Empty;

        [StringLength(100)]
        [Required]
        public string Instagram { get; set; } = string.Empty;

        [StringLength(100)]
        [Required]
        public string City { get; set; } = string.Empty;

        [StringLength(100)]
        [Required]
        public string Country { get; set; } = string.Empty;
    }
}
