namespace Auction.Application.Features.Products.ChangeQuantity
{
    public record ChangeQuantityProductCommand(long Id, long Quantity) : ICommand<Result<ResponseProductDto>>;

}
