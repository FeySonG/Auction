namespace Auction.Application.Contracts.ServiceLayers;

public class UpdateServiceLayerDTO
{
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public string? ServiceName { get; set; }
   
    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string? Description { get; set; }

    public decimal? Price { get; set; }

    [EnumDataType(typeof(ServiceLayerCategory))]
    public ServiceLayerCategory? Category { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? UploadFile { get; set; }

}
