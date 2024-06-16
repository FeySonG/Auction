namespace Auction.Application.Contracts.Users;

public class CreateUserDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public required string NickName { get; set; }

    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [EmailAddress(ErrorMessage = Message.EMAIL)]
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PasswordConfirm { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
