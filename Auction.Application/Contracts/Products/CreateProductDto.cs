namespace Auction.Application.Contracts.Products;

public class CreateProductDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string ProductName { get; set; }

    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string Description { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [Range(1, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public long Quantity { get; set; }

    [Required(ErrorMessage = Message.REQUIRED)]
    [EnumDataType(typeof(ProductCategory))]
    public required ProductCategory Category { get; set; }
}