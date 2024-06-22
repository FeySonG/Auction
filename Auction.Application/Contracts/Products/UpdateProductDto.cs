namespace Auction.Application.Contracts.Products;

/// <summary>
/// DTO for updating product details.
/// </summary>
public class UpdateProductDTO
{
    /// <summary>
    /// Gets or sets the updated name of the product.
    /// </summary>
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [RegularExpression(@"^[\p{L}][\p{L}\s]*[\p{L}]$", ErrorMessage = Message.ONLY_LETTERS)]
    public string? ProductName { get; set; }

    /// <summary>
    /// Gets or sets the updated description of the product.
    /// </summary>
    [MaxLength(300, ErrorMessage = Message.MAX_LENGTH)]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the updated quantity of the product.
    /// </summary>
    [Range(0, long.MaxValue, ErrorMessage = Message.NON_NEGATIVE)]
    public long? Quantity { get; set; }

    /// <summary>
    /// Gets or sets the updated category of the product.
    /// </summary>
    [EnumDataType(typeof(ProductCategory))]
    public ProductCategory? Category { get; set; }
}
