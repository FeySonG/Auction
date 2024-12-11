namespace Auction.Application.Contracts.ServiceLayers;

public class CreateServiceLayerDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string ServiceName { get; set; }

    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = Message.REQUIRED)]
    [EnumDataType(typeof(ServiceLayerCategory))]
    public ServiceLayerCategory? Category { get; set; }
}