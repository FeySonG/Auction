using Auction.Application.Validation;

namespace Auction.Application.Contracts.Users;

public class UpdateUserDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    public required string NickName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public required string FirstName { get; set; }

    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [EmailAddress(ErrorMessage = Message.EMAIL)]
    public required string Email { get; set; }
}
