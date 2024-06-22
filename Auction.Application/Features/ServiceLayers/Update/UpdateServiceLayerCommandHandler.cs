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

        if (request.Dto.Category == null || request.Dto.Category == 0)
            request.Dto.Category = service.Category;

        if (request.Dto.ServiceName == null || request.Dto.ServiceName == "string")
            request.Dto.ServiceName = service.ServiceName;

        if (request.Dto.Description == null || request.Dto.Description == "string")
            request.Dto.Description = service.Description;

        mapper.Map(request.Dto, service);

        serviceLayerRepository.Update(service);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<GetServiceLayerDTO>(service);
    }
}