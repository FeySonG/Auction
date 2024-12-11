namespace Auction.Application.Contracts.Users;

public class CreateUserDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string NickName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string FirstName { get; set; }

    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? LastName { get; set; }

    [MaxLength(40, ErrorMessage = Message.MAX_LENGTH)]
    [EmailAddress(ErrorMessage = Message.EMAIL)]
    public required string Email { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(30, ErrorMessage = Message.MAX_LENGTH)]
    public required string Password { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(30, ErrorMessage = Message.MAX_LENGTH)]
    public required string PasswordConfirm { get; set; }


}
