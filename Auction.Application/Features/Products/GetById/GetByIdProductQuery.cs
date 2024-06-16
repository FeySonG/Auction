namespace Auction.Application.Features.Products.GetById;

public record GetByIdProductQuery(int Id) : IQuery<Result<GetProductDTO>>;