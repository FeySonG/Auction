namespace Auction.Application.Features.ServiceLayers.GetByName
{
    public class GetByNameServiceLayerQueryHandler(
        IServiceLayerRepository serviceLayerRepository,
        IMapper mapper)
        : IQueryHandler<GetByNameServiceLayerQuery, Result<List<ResponseServiceLayerDto>>>
    {
        public async Task<Result<List<ResponseServiceLayerDto>>> Handle(GetByNameServiceLayerQuery request, CancellationToken cancellationToken)
        {
            var service = await serviceLayerRepository.GetByName(request.ServiceName);
            if (service == null)
                return new Error(ServiceLayerErrorCode.ServiceNotFound, ServiceLayerErrorMessage.ServiceNotFound);
            return mapper.Map<List<ResponseServiceLayerDto>>(service);
        }
    }
}
