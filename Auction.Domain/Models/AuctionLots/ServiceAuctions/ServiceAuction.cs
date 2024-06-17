namespace Auction.Domain.Models.AuctionLots.ServiceAuctions;

public class ServiceAuction : Entity
{
    public required long SallerId { get; set; }

    public long CurrentWinnerId { get; set; }
    
    public required long ServiceId { get; set; }
    
    [StringLength(40)]
    public required string Title { get; set; }
    
    [StringLength(300)]
    public string Description { get; set; } = string.Empty;

    public required decimal StartingPrice { get; set; }

    public decimal CurrentPrice { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    // Navigation properties
    public required ServiceLayer Service { get; set; }

}