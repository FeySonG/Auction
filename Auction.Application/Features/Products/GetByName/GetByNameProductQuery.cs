using Auction.Application.Abstractions;
using Auction.Application.Contracts.Products;
using Auction.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.Products.GetByName
{
    public record GetByNameProductQuery(string Name) : IQuery<Result<ResponseProductDto>>;
}
