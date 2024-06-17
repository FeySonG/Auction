using Auction.Application.Errors.Global;

namespace Auction.Application.Features.Products.GetAll;

internal class GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper) : IQueryHandler<GetAllProductQuery, Result<List<GetProductDTO>>>
{
    public async Task<Result<List<GetProductDTO>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllAsync();
        var responseListProducts = mapper.Map<List<GetProductDTO>>(products);
        if (responseListProducts == null) 
            return new Error(GlobalErrorCode.InternalServerError, GlobalErrorMessage.InternalServerError);

        return responseListProducts;
    }
}