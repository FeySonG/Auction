namespace Auction.Domain.Models.UserContacts;

public class UserContact : Entity
{
    public long UserId { get; set; }

    [StringLength(100)]
    public required string PhoneNumber { get; set; }
    
    [StringLength(100)]
    public string? Telegram { get; set; }

    [StringLength(100)]
    public string? Instagram { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? Country { get; set; }
}