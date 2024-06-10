using Auction.Application.Abstractions;
using Auction.Domain.Result;

namespace Auction.Application.Features.Products.Delete
{
    public record DeleteProductCommand(string productName) : ICommand<Result<bool>>;

}
