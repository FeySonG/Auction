namespace Auction.Application.Contracts.ProductAuctions;

/// <summary>
/// DTO for creating a product auction.
/// </summary>
public class CreateProductAuctionDTO
{
    /// <summary>
    /// Gets or sets the product ID.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    public required long ProductId { get; set; }

    /// <summary>
    /// Gets or sets the title of the auction.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string Title { get; set; }

    /// <summary>
    /// Gets or sets the description of the auction.
    /// </summary>
    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public required string Description { get; set; }

    /// <summary>
    /// Gets or sets the starting price of the auction.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [Range(0, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public required decimal StartingPrice { get; set; }

    /// <summary>
    /// Gets or sets the start time of the auction.
    /// </summary>
    [Required(ErrorMessage = Message.REQUIRED)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy:HH:mm}", ApplyFormatInEditMode = true)]
    [DataType(DataType.DateTime)]
    [Display(Name = "Start Time")]
    [FutureDate(ErrorMessage = Message.CANT_BE_PAST)]
    public required DateTime StartTime { get; set; }

    /// <summary>
    /// Gets or sets the duration of the auction in days.
    /// </summary>
    [Range(1, 5, ErrorMessage = Message.NON_NEGATIVE)]
    public int Duration { get; set; }
}
