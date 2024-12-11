namespace Auction.Application.Contracts.UserContacts;

public class CreateUserContactDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(12, ErrorMessage = Message.MAX_LENGTH)]
    [MinLength(10, ErrorMessage = Message.MIN_LENGTH)]
    [RegularExpression("^[0-9]*$", ErrorMessage = Message.ONLY_DIGITAL)]
    public required string PhoneNumber { get; set; }

    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z\d\s]+$", ErrorMessage = Message.LETTERS_AND_OPTIONAL_DIGITS)]
    public string Telegram { get; set; } = string.Empty;

    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z\d\s]+$", ErrorMessage = Message.LETTERS_AND_OPTIONAL_DIGITS)]
    public string Instagram { get; set; } = string.Empty;

    [MaxLength(100, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.NO_LEADING_TRAILING_SPACES)]
    public string City { get; set; } = string.Empty;

    [MaxLength(100, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.NO_LEADING_TRAILING_SPACES)]
    public string Country { get; set; } = string.Empty;
}
