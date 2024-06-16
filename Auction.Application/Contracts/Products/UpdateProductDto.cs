namespace Auction.Application.Contracts.Products
{
    public class UpdateProductDto
    {
        public required string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }

    }
}
