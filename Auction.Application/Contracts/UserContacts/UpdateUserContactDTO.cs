namespace Auction.Application.Contracts.UserContacts;

/// <summary>
/// DTO for updating user contact information.
/// </summary>
public class UpdateUserContactDTO
{
    /// <summary>
    /// Gets or sets the phone number of the user.
    /// </summary>
    [MaxLength(12, ErrorMessage = Message.MAX_LENGTH)]
    [MinLength(10, ErrorMessage = Message.MIN_LENGTH)]
    [RegularExpression("^[0-9]*$", ErrorMessage = Message.ONLY_DIGITAL)]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the Telegram handle of the user.
    /// </summary>
    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z\d\s]+$", ErrorMessage = Message.LETTERS_AND_OPTIONAL_DIGITS)]
    public string? Telegram { get; set; }

    /// <summary>
    /// Gets or sets the Instagram handle of the user.
    /// </summary>
    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z\d\s]+$", ErrorMessage = Message.LETTERS_AND_OPTIONAL_DIGITS)]
    public string? Instagram { get; set; }

    /// <summary>
    /// Gets or sets the city where the user resides.
    /// </summary>
    [MaxLength(100, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.NO_LEADING_TRAILING_SPACES)]
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the country where the user resides.
    /// </summary>
    [MaxLength(100, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.NO_LEADING_TRAILING_SPACES)]
    public string? Country { get; set; }
}
