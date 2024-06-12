namespace Auction.Application.Features.Products.Update
{
    public record UpdateProductCommand(UpdateProductDto Dto, long Id) : ICommand<Result<ResponseProductDto>>;

}
