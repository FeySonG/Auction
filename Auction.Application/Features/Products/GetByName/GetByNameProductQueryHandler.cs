using Auction.Application.Errors.Product;

namespace Auction.Application.Features.Products.GetByName;

internal class GetByNameProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IQueryHandler<GetByNameProductQuery, Result<List<GetProductDTO>>>
{
    public async Task<Result<List<GetProductDTO>>> Handle(GetByNameProductQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetByName(request.Name);
        if (products.Count == 0)
            return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);
        
        return  mapper.Map<List<GetProductDTO>>(products);

    }
}