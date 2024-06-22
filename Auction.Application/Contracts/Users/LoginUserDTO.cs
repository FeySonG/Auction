namespace Auction.Application.Contracts.Users;

/// <summary>
/// DTO for user login.
/// </summary>
public class LoginUserDTO
{
    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(40, ErrorMessage = Message.MAX_LENGTH)]
    [EmailAddress(ErrorMessage = Message.EMAIL)]
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(30, ErrorMessage = Message.MAX_LENGTH)]
    public required string Password { get; set; }
}
