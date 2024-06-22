namespace Auction.Application.Contracts.Users;

public class GetUserDTO
{
    public long Id { get; set; }    
    public string? NickName { get; set; } 
    public string? FirstName { get; set; } 
    public string? LastName { get; set; } 
    public string? Email { get; set; } 
    public UserRole Role { get; set; }
}