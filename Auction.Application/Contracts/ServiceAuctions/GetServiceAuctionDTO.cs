namespace Auction.Application.Contracts.ServiceAuctions;

/// <summary>
/// DTO for retrieving details of a service auction.
/// </summary>
public class GetServiceAuctionDTO
{
    /// <summary>
    /// Gets or sets the ID of the service auction.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the seller associated with the service auction.
    /// </summary>
    public long SallerId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the current winner of the service auction.
    /// </summary>
    public long CurrentWinnerId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the service associated with the auction.
    /// </summary>
    public long ServiceId { get; set; }

    /// <summary>
    /// Gets or sets the title of the service auction.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the service auction.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the starting price of the service auction.
    /// </summary>
    public decimal StartingPrice { get; set; }

    /// <summary>
    /// Gets or sets the current price of the service auction.
    /// </summary>
    public decimal CurrentPrice { get; set; }

    /// <summary>
    /// Gets or sets the start time of the service auction.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Gets or sets the end time of the service auction.
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Gets or sets the associated service entity.
    /// </summary>
    public ServiceLayer? Service { get; set; }
}
