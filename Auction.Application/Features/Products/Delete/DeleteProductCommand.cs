namespace Auction.Application.Features.Products.Delete
{
    public record DeleteProductCommand(long Id) : ICommand<Result<bool>>;

}
