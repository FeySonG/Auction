namespace Auction.Application.Contracts.Products;

/// <summary>
/// DTO for creating a new product.
/// </summary>
public class CreateProductDTO
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public required string ProductName { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [Range(1, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public long Quantity { get; set; }

    /// <summary>
    /// Gets or sets the category of the product.
    /// </summary>
    [Required(ErrorMessage = Message.REQUIRED)]
    [EnumDataType(typeof(ProductCategory))]
    public required ProductCategory Category { get; set; }
}
