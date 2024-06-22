namespace Auction.Application.Features.Products.GetUserProduct;

internal class GetUserProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IQueryHandler<GetUserProductQuery, Result<List<GetProductDTO>>>
{

    public async Task<Result<List<GetProductDTO>>> Handle(GetUserProductQuery request, CancellationToken cancellationToken)
    {
       
        var userProducts = await productRepository.GetUserProducts(request.UserId);
        if (userProducts == null)
            return new Error(ProductErrorCode.UserHasNoProducts, ProductErrorMessage.UserHasNoProducts);

        return mapper.Map<List<GetProductDTO>>(userProducts);;

    }
}