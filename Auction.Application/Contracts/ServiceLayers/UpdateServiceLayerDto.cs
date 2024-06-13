namespace Auction.Application.Contracts.Services
{
    public class UpdateServiceLayerDto
    {
        public required string ServiceName { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
    }
}
