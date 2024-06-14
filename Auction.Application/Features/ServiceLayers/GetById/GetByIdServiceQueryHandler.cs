namespace Auction.Application.Features.ServiceLayers.GetById
{
    internal class GetByIdServiceQueryHandler(IServiceLayerRepository repository, IMapper mapper)
       : IQueryHandler<GetByIdServiceQuery, Result<ResponseServiceLayerDto>>
    {
        public async Task<Result<ResponseServiceLayerDto>> Handle(GetByIdServiceQuery request, CancellationToken cancellationToken)
        {
            var product = await repository.GetById(request.Id);
            if (product == null)
                return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

            return mapper.Map<ResponseServiceLayerDto>(product);
        }
    }
}
