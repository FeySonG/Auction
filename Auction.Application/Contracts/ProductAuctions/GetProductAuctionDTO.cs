namespace Auction.Application.Contracts.ProductAuctions;
public class GetProductAuctionDTO
{
    public long Id { get; set; }
    public required long SallerId { get; set; }
    public long CurrentWinnerId { get; set; }
    public long ProductId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required Product Product { get; set; }
    public required decimal StartingPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
