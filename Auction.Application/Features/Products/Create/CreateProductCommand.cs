namespace Auction.Application.Features.Products.Create
{
    public record CreateProductCommand(CreateProductDto Dto) : ICommand<Result<CreateProductDto>>;

}
