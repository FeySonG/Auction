namespace Auction.Application.Contracts.Products;

public class UpdateProductDTO
{
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? ProductName { get; set; }

    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string? Description { get; set; }

    [Range(0, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public long? Quantity { get; set; }

    [EnumDataType(typeof(ProductCategory))]
    public ProductCategory? Category { get; set; }
}
