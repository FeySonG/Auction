namespace Auction.Domain.Models.UserContacts;

public class UserContact : Entity
{
    public required long UserId { get; set; }

    [StringLength(22)]
    public required string PhoneNumber { get; set; }
    
    [StringLength(20)]
    public string Telegram { get; set; } = string.Empty;

    [StringLength(20)]
    public string Instagram { get; set; } = string.Empty;

    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [StringLength(100)]
    public string Country { get; set; } = string.Empty;
}