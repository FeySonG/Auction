namespace Auction.Application.Contracts.Products;

public class CreateProductDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public required string ProductName { get; set; }

    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string Description { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [Range(0, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public required decimal Price { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [Range(1, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public long Quantity { get; set; }

    [Required(ErrorMessage = Message.REQUIRED)]
    [EnumDataType(typeof(ProductCategory))]
    public required ProductCategory Category { get; set; }

    public IFormFile? UploadFile { get; set; }
    public string? ImagePath { get; set; }
}