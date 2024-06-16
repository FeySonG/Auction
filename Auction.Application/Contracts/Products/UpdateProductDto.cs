﻿namespace Auction.Application.Contracts.Products;

public class UpdateProductDTO
{
    public required string ProductName { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
