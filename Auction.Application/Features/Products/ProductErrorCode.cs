using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.Products
{
    public class ProductErrorCode
    {
        public const string ProductIsNull = "Product.IsNull";
        public const string UserHasNoProducts = "Product.UserHasNoProducts";
        public const string ProductNotFound = "Product.NotFound";

    }
}
