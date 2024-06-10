using Auction.Application.Abstractions;
using Auction.Application.Contracts.Products;
using Auction.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Auction.Application.Features.Products.Update
{
    public record UpdateProductCommand(UpdateProductDto Dto, string ProductName) : ICommand<Result<ResponseProductDto>>;

}
