namespace Auction.Application.Contracts.Products;

public class UpdateProductDTO
{
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public string? ProductName { get; set; }

    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string? Description { get; set; }

    [Range(0, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public decimal? Price { get; set; }

    [Range(0, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public long? Quantity { get; set; }

    [EnumDataType(typeof(ProductCategory))]
    public ProductCategory? Category { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? UploadFile { get; set; }
}
