using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Contracts.Products
{
    public class UpdateProductDto
    {
        public required string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
