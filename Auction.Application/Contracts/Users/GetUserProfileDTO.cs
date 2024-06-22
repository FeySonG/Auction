namespace Auction.Application.Contracts.Users;

public class GetUserProfileDTO
{
    public  string? NickName { get; set; }
    public  string? FirstName { get; set; }
    public  string? LastName { get; set; }
    public  string? Email { get; set; }

    // Navigation properties
    public GetUserContactDTO? Contact { get; set; }
    public GetPaymentCardDTO? BankCard { get; set; }
}