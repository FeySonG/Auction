namespace Auction.Application.Contracts.UserContacts;

public class UpdateUserContactDTO
{
    [MaxLength(22, ErrorMessage = Message.MAX_LENGTH)]
    public string? PhoneNumber { get; set; }

    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    public string? Telegram { get; set; }

    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    public string? Instagram { get; set; }

    [MaxLength(100, ErrorMessage = Message.MAX_LENGTH)]
    public string? City { get; set; }

    [MaxLength(100, ErrorMessage = Message.MAX_LENGTH)]
    public string? Country { get; set; }
}