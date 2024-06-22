namespace Auction.Application.Contracts.ServiceAuctions;

public class GetServiceAuctionDTO
{
    public long Id { get; set; }
    public long SallerId { get; set; }
    public long CurrentWinnerId { get; set; }
    public long ServiceId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal StartingPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    // Navigation properties
    public ServiceLayer? Service { get; set; }
}