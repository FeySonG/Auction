using Auction.Application.Errors.ServiceLayer;

namespace Auction.Application.Features.ServiceLayers.Update;

internal class UpdateServiceLayerCommandHandler(
    IServiceLayerRepository serviceLayerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) 
    : ICommandHandler<UpdateServiceLayerCommand, Result<GetServiceLayerDTO>>
{
    public async Task<Result<GetServiceLayerDTO>> Handle(UpdateServiceLayerCommand request, CancellationToken cancellationToken)
    {
        var service = await serviceLayerRepository.GetById(request.id);
        if (service == null) 
            return new Error(ServiceLayerErrorCode.ServiceNotFound, ServiceLayerErrorMessage.ServiceNotFound);
       
        mapper.Map(request.Dto, service);

        serviceLayerRepository.Update(service);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<GetServiceLayerDTO>(service);
    }
}