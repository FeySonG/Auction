namespace Auction.Application.Contracts.ServiceLayers;

public class CreateServiceLayerDTO
{
    public required string ServiceName { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
}
