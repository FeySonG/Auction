namespace Auction.Application.Features.Products.GetById
{
    public class GetByIdProductQueryHandler (IProductRepository repository, IMapper mapper)
        : IQueryHandler<GetByIdProductQuery, Result<ResponseProductDto>>
    {
        public async Task<Result<ResponseProductDto>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await repository.GetById(request.Id);
            if (product == null)
                return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

            return mapper.Map<ResponseProductDto>(product);
        }
    }
}
