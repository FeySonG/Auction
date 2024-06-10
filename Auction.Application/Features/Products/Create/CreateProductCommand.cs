using Auction.Application.Abstractions;
using Auction.Application.Contracts.Profucts;
using Auction.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Auction.Application.Features.Products.Create
{
    public record CreateProductCommand(CreateProductDto Dto) : ICommand<Result<CreateProductDto>>;

}
