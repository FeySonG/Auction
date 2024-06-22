namespace Auction.Application.Contracts.ServiceLayers;

/// <summary>
/// DTO for creating a service layer.
/// </summary>
public class CreateServiceLayerDTO
{
    /// <summary>
    /// Gets or sets the name of the service layer.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string ServiceName { get; set; }

    /// <summary>
    /// Gets or sets the description of the service layer.
    /// </summary>
    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category of the service layer.
    /// </summary>
    [Required(ErrorMessage = Message.REQUIRED)]
    [EnumDataType(typeof(ServiceLayerCategory))]
    public ServiceLayerCategory? Category { get; set; }
}
