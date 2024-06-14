using Auction.Domain.Abstractions;

namespace Auction.Domain.Models.Products
{
    public class Product : Entity
    {
        public long UserId { get; set; }
        public required string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0;
        public long Quantity { get; set; } = 1;
        public ProductCategory Category { get; set; } = ProductCategory.Unknown;
        public string ImagePath { get; set; } = string.Empty;

    }
}
