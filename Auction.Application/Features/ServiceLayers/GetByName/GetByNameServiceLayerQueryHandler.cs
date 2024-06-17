using Auction.Application.Errors.ServiceLayer;

namespace Auction.Application.Features.ServiceLayers.GetByName;

internal class GetByNameServiceLayerQueryHandler(
    IServiceLayerRepository serviceLayerRepository,
    IMapper mapper)
    : IQueryHandler<GetByNameServiceLayerQuery, Result<List<GetServiceLayerDTO>>>
{
    public async Task<Result<List<GetServiceLayerDTO>>> Handle(GetByNameServiceLayerQuery request, CancellationToken cancellationToken)
    {
        var service = await serviceLayerRepository.GetByName(request.ServiceName);
        if (service == null)
            return new Error(ServiceLayerErrorCode.ServiceNotFound, ServiceLayerErrorMessage.ServiceNotFound);
        return mapper.Map<List<GetServiceLayerDTO>>(service);
    }
}