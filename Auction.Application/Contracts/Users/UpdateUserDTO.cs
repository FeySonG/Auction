namespace Auction.Application.Contracts.Users;

public class UpdateUserDTO
{
    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? NickName { get; set; }

    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? FirstName { get; set; }

    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? LastName { get; set; }

    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [EmailAddress(ErrorMessage = Message.EMAIL)]
    public string? Email { get; set; }
}