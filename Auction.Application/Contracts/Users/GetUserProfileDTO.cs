namespace Auction.Application.Contracts.Users;

public class GetUserProfileDTO
{
    public  string NickName { get; set; } = string.Empty;
    public  string FirstName { get; set; } = string.Empty;
    public  string LastName { get; set; } = string.Empty;
    public  string Email { get; set; } = string.Empty;
    public GetUserContactDTO? Contact { get; set; }
    public GetPaymentCardDTO? BankCard { get; set; }
}
