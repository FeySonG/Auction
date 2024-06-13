namespace Auction.Application.Features.ServiceLayers.Update
{
    public class UpdateServiceLayerCommandHandler(
        IServiceLayerRepository serviceLayerRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) 
        : ICommandHandler<UpdateServiceLayerCommand, Result<ResponseServiceLayerDto>>
    {
        public async Task<Result<ResponseServiceLayerDto>> Handle(UpdateServiceLayerCommand request, CancellationToken cancellationToken)
        {
            var service = await serviceLayerRepository.GetById(request.id);
            if (service == null) 
                return new Error(ServiceLayerErrorCode.ServiceNotFound, ServiceLayerErrorMessage.ServiceNotFound);
           
            mapper.Map(request.Dto, service);

            serviceLayerRepository.Update(service);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<ResponseServiceLayerDto>(service);
        }
    }
}
