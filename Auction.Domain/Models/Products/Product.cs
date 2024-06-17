namespace Auction.Domain.Models.Products;

public class Product : Entity
{
    public required long UserId { get; set; }
    
    [StringLength(50)]
    public required string ProductName { get; set; }

    [StringLength(300)]
    public string Description { get; set; } = string.Empty;

    public required decimal Price { get; set; } = 0;

    public required long Quantity { get; set; } = 1;

    public required ProductCategory Category { get; set; } = ProductCategory.Unknown;

    public string ImagePath { get; set; } = string.Empty;

}