using Auction.Domain.Abstractions;
using Auction.Domain.Models.Products;

namespace Auction.Domain.Models.AuctionLots.ProductAuctions
{
    public class ProductAuction : Entity
    {
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
}
