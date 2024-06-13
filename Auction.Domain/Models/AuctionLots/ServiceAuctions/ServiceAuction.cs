using Auction.Domain.Abstractions;
using Auction.Domain.Models.ServiceLayers;


namespace Auction.Domain.Models.AuctionLots.ServiceAuctions
{
    public class ServiceAuction : Entity
    {
        public required long SallerId { get; set; }
        public long CurrentWinnerId { get; set; }
        public long ServiceId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required ServiceLayer Service { get; set; }
        public required decimal StartingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
