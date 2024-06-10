using Auction.Domain.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Contracts.Services
{
    public class ResponseServiceLayerDto
    {
        public required long UserId { get; set; }
        public required string ServiceName { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public ServiceLayerCategory? Category { get; set; }
    }
}
