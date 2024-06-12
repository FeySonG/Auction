namespace Auction.Application.Features.Products.GetByName
{
    public record GetByNameProductQuery(string Name) : IQuery<Result<List<ResponseProductDto>>>;
}
