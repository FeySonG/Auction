namespace Auction.Application.Contracts.ServiceLayers;

public class UpdateServiceLayerDTO
{
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? ServiceName { get; set; }
   
    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string? Description { get; set; }

    [EnumDataType(typeof(ServiceLayerCategory))]
    public ServiceLayerCategory? Category { get; set; }
}
