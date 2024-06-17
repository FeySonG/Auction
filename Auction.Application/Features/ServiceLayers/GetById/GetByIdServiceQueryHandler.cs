using Auction.Application.Errors.Product;

namespace Auction.Application.Features.ServiceLayers.GetById;

internal class GetByIdServiceQueryHandler(IServiceLayerRepository repository, IMapper mapper)
   : IQueryHandler<GetByIdServiceQuery, Result<GetServiceLayerDTO>>
{
    public async Task<Result<GetServiceLayerDTO>> Handle(GetByIdServiceQuery request, CancellationToken cancellationToken)
    {
        var product = await repository.GetById(request.Id);
        if (product == null)
            return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

        return mapper.Map<GetServiceLayerDTO>(product);
    }
}