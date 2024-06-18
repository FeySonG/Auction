namespace Auction.Application.Features.Products.GetById;

internal class GetByIdProductQueryHandler (IProductRepository repository, IMapper mapper)
    : IQueryHandler<GetByIdProductQuery, Result<GetProductDTO>>
{
    public async Task<Result<GetProductDTO>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var product = await repository.GetById(request.Id);
        if (product == null)
            return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

        return mapper.Map<GetProductDTO>(product);
    }
}