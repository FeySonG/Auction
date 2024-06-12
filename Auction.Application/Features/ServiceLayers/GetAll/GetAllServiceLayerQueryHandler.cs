namespace Auction.Application.Features.ServiceLayers.GetAll
{
    public class GetAllServiceLayerQueryHandler(IServiceLayerRepository serviceLayerRepository,
        IMapper mapper) 
        : IQueryHandler<GetAllServiceLayerQuery, Result<List<ResponseServiceLayerDto>>>
    {
        public async Task<Result<List<ResponseServiceLayerDto>>> Handle(GetAllServiceLayerQuery request, CancellationToken cancellationToken)
        {
            var serviceLayers = await serviceLayerRepository.GetAllAsync();
            if(serviceLayers == null) 
                return new Error(GlobalErrorCode.InternalServerError, GlobalErrorMessage.InternalServerError);
            return mapper.Map<List<ResponseServiceLayerDto>>(serviceLayers);
        }
    }
}
