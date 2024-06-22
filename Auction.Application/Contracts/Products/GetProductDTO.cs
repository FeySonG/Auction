namespace Auction.Application.Contracts.Products;

/// <summary>
/// DTO for retrieving product details.
/// </summary>
public class GetProductDTO
{
    /// <summary>
    /// Gets or sets the identifier of the product.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who owns the product.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    public long Quantity { get; set; }

    /// <summary>
    /// Gets or sets the category of the product.
    /// </summary>
    public ProductCategory Category { get; set; }
}
