namespace Auction.Domain.Models.ServiceLayers;

public class ServiceLayer : Entity
{
    public required long UserId { get; set; }

    [StringLength(50)]
    public required string ServiceName { get; set; }

    [StringLength(300)]
    public string Description { get; set; } = string.Empty;

    public required decimal Price { get; set; }

    public ServiceLayerCategory? Category { get; set; }

    public string ImagePath { get; set; } = string.Empty;

}