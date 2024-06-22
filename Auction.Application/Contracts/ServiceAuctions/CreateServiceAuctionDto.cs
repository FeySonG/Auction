namespace Auction.Application.Contracts.ServiceAuctions;

public class CreateServiceAuctionDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    public required long ServiceId { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string Title { get; set; }

    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string Description { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [Range(10, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public required decimal StartingPrice { get; set; }

    [Required(ErrorMessage = Message.REQUIRED)]
    [FutureDate(ErrorMessage = Message.CANT_BE_PAST)]
    public required DateTime StartTime { get; set; }

    [Range(1, 5, ErrorMessage = Message.NON_NEGATIVE)]
    public int Duration { get; set; }
}
