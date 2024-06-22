namespace Auction.Application.Contracts.UserContacts;

/// <summary>
/// DTO for creating a user contact.
/// </summary>
public class CreateUserContactDTO
{
    /// <summary>
    /// Gets or sets the phone number of the user.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(12, ErrorMessage = Message.MAX_LENGTH)]
    [MinLength(10, ErrorMessage = Message.MIN_LENGTH)]
    [RegularExpression("^[0-9]*$", ErrorMessage = Message.ONLY_DIGITAL)]
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the Telegram handle of the user.
    /// </summary>
    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z\d\s]+$", ErrorMessage = Message.LETTERS_AND_OPTIONAL_DIGITS)]
    public string Telegram { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Instagram handle of the user.
    /// </summary>
    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z\d\s]+$", ErrorMessage = Message.LETTERS_AND_OPTIONAL_DIGITS)]
    public string Instagram { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the city where the user resides.
    /// </summary>
    [MaxLength(100, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.NO_LEADING_TRAILING_SPACES)]
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the country where the user resides.
    /// </summary>
    [MaxLength(100, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.NO_LEADING_TRAILING_SPACES)]
    public string Country { get; set; } = string.Empty;
}
