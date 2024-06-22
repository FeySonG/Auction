namespace Auction.Application.Features.Products.GetUserProduct;

public record GetUserProductQuery(long UserId) : IQuery<Result<List<GetProductDTO>>>;