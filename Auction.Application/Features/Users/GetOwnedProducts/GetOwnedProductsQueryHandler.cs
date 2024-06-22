namespace Auction.Application.Features.Users.GetOwnedProducts;

internal class GetOwnedProductsQueryHandler(IProductRepository repository, IMapper mapper) : IQueryHandler<GetOwnedProductsQuery, Result<List<GetProductDTO>>>
{
    public async Task<Result<List<GetProductDTO>>> Handle(GetOwnedProductsQuery request, CancellationToken cancellationToken)
    {
        var ownedProducts = await repository.GetUserOwnedProducts(request.UserID);

        if (ownedProducts.Count == 0)
            return new Error(ProductErrorCode.ProductNoContent, ProductErrorMessage.UserHasNoProducts);
        return mapper.Map<List<GetProductDTO>>(ownedProducts);
    }
}
