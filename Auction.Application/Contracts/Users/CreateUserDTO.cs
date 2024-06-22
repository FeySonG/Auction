namespace Auction.Application.Contracts.Users;

/// <summary>
/// DTO for creating a user.
/// </summary>
public class CreateUserDTO
{
    /// <summary>
    /// Gets or sets the nickname of the user.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string NickName { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [MaxLength(40, ErrorMessage = Message.MAX_LENGTH)]
    [EmailAddress(ErrorMessage = Message.EMAIL)]
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(30, ErrorMessage = Message.MAX_LENGTH)]
    public required string Password { get; set; }

    /// <summary>
    /// Gets or sets the confirmation of the user's password.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(30, ErrorMessage = Message.MAX_LENGTH)]
    public required string PasswordConfirm { get; set; }
}
