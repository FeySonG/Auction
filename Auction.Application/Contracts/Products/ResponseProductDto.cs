﻿using Auction.Domain.Models.Products;

namespace Auction.Application.Contracts.Products
{
    public class ResponseProductDto
    {
        public long UsertId { get; set; }   
        public required string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0;
        public long Quantity { get; set; } = 1;
        public ProductCategory Category { get; set; } = ProductCategory.Unknown;
    }
}