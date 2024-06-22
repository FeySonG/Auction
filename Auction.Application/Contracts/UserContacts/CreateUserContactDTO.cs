namespace Auction.Application.Contracts.UserContacts;

public class CreateUserContactDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(12, ErrorMessage = Message.MAX_LENGTH)]
    [MinLength(10, ErrorMessage = Message.MIN_LENGTH)]
    public required string PhoneNumber { get; set; }

    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    public string Telegram { get; set; } = string.Empty;

    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    public string Instagram { get; set; } = string.Empty;

    [MaxLength(100, ErrorMessage = Message.MAX_LENGTH)]
    public string City { get; set; } = string.Empty;

    [MaxLength(100, ErrorMessage = Message.MAX_LENGTH)]
    public string Country { get; set; } = string.Empty;
}
