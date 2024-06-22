namespace Auction.Application.Contracts.Users;

/// <summary>
/// DTO for updating user information.
/// </summary>
public class UpdateUserDTO
{
    /// <summary>
    /// Gets or sets the nickname of the user.
    /// </summary>
    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? NickName { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [EmailAddress(ErrorMessage = Message.EMAIL)]
    public string? Email { get; set; }
}
