namespace Auction.Application.Contracts.ServiceLayers;

/// <summary>
/// DTO for retrieving a service layer.
/// </summary>
public class GetServiceLayerDTO
{
    /// <summary>
    /// Gets or sets the ID of the service layer.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user associated with the service layer.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Gets or sets the name of the service layer.
    /// </summary>
    public string ServiceName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the service layer.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category of the service layer.
    /// </summary>
    public ServiceLayerCategory Category { get; set; }
}
