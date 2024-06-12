namespace Auction.Application.Contracts.ProductAuctions
{
    public class CreateProductAuctionDto
    {
        public long ProductId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required decimal StartingPrice { get; set; }
        public DateTime StartTime { get; set; }
    }
}
