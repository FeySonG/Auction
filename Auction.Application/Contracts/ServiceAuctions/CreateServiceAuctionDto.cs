namespace Auction.Application.Contracts.ServiceAuctions;

public class CreateServiceAuctionDTO
{
    public long ServiceId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required decimal StartingPrice { get; set; }
    public DateTime StartTime { get; set; }
}
