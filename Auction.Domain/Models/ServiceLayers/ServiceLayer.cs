using Auction.Domain.Abstractions;

namespace Auction.Domain.Models.ServiceLayers
{
    public class ServiceLayer : Entity
    {
        public required long UserId { get; set; }
        public required string ServiceName { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public ServiceLayerCategory? Category { get; set; }
    }
}
