namespace Auction.Application.Contracts.ServiceAuctions;

/// <summary>
/// DTO for creating a service auction.
/// </summary>
public class CreateServiceAuctionDTO
{
    /// <summary>
    /// Gets or sets the ID of the service associated with the auction.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    public long ServiceId { get; set; }

    /// <summary>
    /// Gets or sets the title of the service auction.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string Title { get; set; }

    /// <summary>
    /// Gets or sets the description of the service auction.
    /// </summary>
    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the starting price of the service auction.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [Range(10, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public decimal StartingPrice { get; set; }

    /// <summary>
    /// Gets or sets the start time of the service auction.
    /// </summary>
    [Required(ErrorMessage = Message.REQUIRED)]
    [FutureDate(ErrorMessage = Message.CANT_BE_PAST)]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Gets or sets the duration of the service auction.
    /// </summary>
    [Range(1, 5, ErrorMessage = Message.NON_NEGATIVE)]
    public int Duration { get; set; }
}
