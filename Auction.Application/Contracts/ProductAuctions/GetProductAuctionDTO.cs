namespace Auction.Application.Contracts.ProductAuctions;

/// <summary>
/// DTO for retrieving product auction details.
/// </summary>
public class GetProductAuctionDTO
{
    /// <summary>
    /// Gets or sets the ID of the auction.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the seller.
    /// </summary>
    public long SallerId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the current winner.
    /// </summary>
    public long CurrentWinnerId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the product associated with the auction.
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    /// Gets or sets the title of the auction.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the auction.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product details associated with the auction.
    /// </summary>
    public required Product Product { get; set; }

    /// <summary>
    /// Gets or sets the starting price of the auction.
    /// </summary>
    public decimal StartingPrice { get; set; }

    /// <summary>
    /// Gets or sets the current price of the auction.
    /// </summary>
    public decimal CurrentPrice { get; set; }

    /// <summary>
    /// Gets or sets the start time of the auction.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Gets or sets the end time of the auction.
    /// </summary>
    public DateTime EndTime { get; set; }
}
