using Auction.Application.Validation;

namespace Auction.Application.Contracts.ServiceLayers;

public class UpdateServiceLayerDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public required string ServiceName { get; set; }
   
    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string Description { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    public required decimal Price { get; set; }
}
