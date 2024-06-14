namespace Auction.Application.Features.Products.GetByName
{
    public class GetByNameProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        : IQueryHandler<GetByNameProductQuery, Result<List<ResponseProductDto>>>
    {
        public async Task<Result<List<ResponseProductDto>>> Handle(GetByNameProductQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetByName(request.Name);
            if (products.Count == 0)
                return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);
            
            return  mapper.Map<List<ResponseProductDto>>(products);

        }
    }
}
