namespace Auction.Application.Contracts.Products;

public class GetProductDTO
{
    public int Id { get; set; } 
    public long UserId { get; set; }   
    public string ProductName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public long Quantity { get; set; }
    public ProductCategory Category { get; set; }
    public string? ImagePath { get; set; }
}
