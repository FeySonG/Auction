namespace Auction.Application.Features.Users.GetOwnedProducts;

public record GetOwnedProductsQuery(int UserID) : IQuery<Result<List<GetProductDTO>>>;