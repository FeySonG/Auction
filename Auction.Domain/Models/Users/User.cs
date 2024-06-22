namespace Auction.Domain.Models.Users;

public class User : Entity
{
    [MaxLength(20)]
    public required string NickName { get; set; }

    [MaxLength(50)]
    public required string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    public required string Password { get; set; }

    [MaxLength(40)]
    public required string Email { get; set; }

    public UserRole Role { get; set; } = UserRole.User;

    // Navigation properties
    public PaymentCard? BankCard { get; set; }
    public UserContact? Contact { get; set; }
    public List<Product>? Products { get; set; }
    public List<ServiceLayer>? ServicesLayer { get; set; }
}