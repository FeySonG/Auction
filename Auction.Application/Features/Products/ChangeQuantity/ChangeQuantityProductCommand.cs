using Auction.Application.Abstractions;
using Auction.Application.Contracts.Products;
using Auction.Domain.Result;

namespace Auction.Application.Features.Products.ChangeQuantity
{
    public record ChangeQuantityProductCommand(string ProductName, long Quantity) : ICommand<Result<ResponseProductDto>>;

}
