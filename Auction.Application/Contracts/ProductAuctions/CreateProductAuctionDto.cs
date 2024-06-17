using Auction.Application.Validation;

namespace Auction.Application.Contracts.ProductAuctions;

public class CreateProductAuctionDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    public required long ProductId { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public required string Title { get; set; }

    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public required string Description { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [Range(0, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public required decimal StartingPrice { get; set; }

    [Required(ErrorMessage = Message.REQUIRED)]
    [FutureDate(ErrorMessage = Message.CANT_BE_PAST)]
    public required DateTime StartTime { get; set; }
}
