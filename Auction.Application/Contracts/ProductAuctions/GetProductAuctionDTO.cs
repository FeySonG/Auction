namespace Auction.Application.Contracts.ProductAuctions;

public class GetProductAuctionDTO
{
    public long Id { get; set; }
    public long SallerId { get; set; }
    public long CurrentWinnerId { get; set; }
    public long ProductId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public required Product Product { get; set; }
    public decimal StartingPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

}