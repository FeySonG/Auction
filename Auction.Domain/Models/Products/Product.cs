using Auction.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
