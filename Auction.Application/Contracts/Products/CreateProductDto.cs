namespace Auction.Application.Contracts.Products
{
    public class CreateProductDto
    {
        public required string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0;
        public long Quantity { get; set; } = 1;
        public string? ImagePath { get; set; }
        public IFormFile? UploadFile { get; set; }

        public ProductCategory Category { get; set; } = ProductCategory.Unknown;
    }
}
