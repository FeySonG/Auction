namespace Auction.Application.Contracts.Services
{
    public class CreateServiceLayerDto
    {
        public required string ServiceName { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
    }
}
