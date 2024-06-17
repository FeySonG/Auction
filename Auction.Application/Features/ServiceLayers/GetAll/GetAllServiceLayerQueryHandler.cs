using Auction.Application.Errors.Global;

namespace Auction.Application.Features.ServiceLayers.GetAll;

internal class GetAllServiceLayerQueryHandler(IServiceLayerRepository serviceLayerRepository,
    IMapper mapper) 
    : IQueryHandler<GetAllServiceLayerQuery, Result<List<GetServiceLayerDTO>>>
{
    public async Task<Result<List<GetServiceLayerDTO>>> Handle(GetAllServiceLayerQuery request, CancellationToken cancellationToken)
    {
        var serviceLayers = await serviceLayerRepository.GetAllAsync();
        if(serviceLayers == null) 
            return new Error(GlobalErrorCode.InternalServerError, GlobalErrorMessage.InternalServerError);
        return mapper.Map<List<GetServiceLayerDTO>>(serviceLayers);
    }
}