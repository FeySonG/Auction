namespace Auction.Application.Contracts.ServiceAuctions;

public class CreateServiceAuctionDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    public required long ServiceId { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public required string Title { get; set; }

    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string Description { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    public required decimal StartingPrice { get; set; }


    [Required(ErrorMessage = Message.REQUIRED)]
    [FutureDate(ErrorMessage = Message.CANT_BE_PAST)]
    public required DateTime StartTime { get; set; }
}
