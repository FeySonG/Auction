namespace Auction.Application.Contracts.UserContacts;

public class GetUserContactDTO
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Telegram { get; set; } = string.Empty;
    public string Instagram { get; set; } = string.Empty; 
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}