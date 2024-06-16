namespace Auction.Application.Contracts.ServiceLayers;

public class GetServiceLayerDTO
{
    public long Id { get; set; }
    public required long UserId { get; set; }
    public required string ServiceName { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public ServiceLayerCategory? Category { get; set; }
}
