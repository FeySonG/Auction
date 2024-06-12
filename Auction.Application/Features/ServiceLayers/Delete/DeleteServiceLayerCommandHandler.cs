namespace Auction.Application.Features.ServiceLayers.Delete
{
    public class DeleteServiceLayerCommandHandler(
        IServiceLayerRepository serviceLayerRepository,
        IUnitOfWork unitOfWork) 
        : ICommandHandler<DeleteServiceLayerCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteServiceLayerCommand request, CancellationToken cancellationToken)
        {
            var service = await serviceLayerRepository.GetById(request.Id);
            if (service == null)
                return new Error(ServiceLayerErrorCode.ServiceNotFound, ServiceLayerErrorMessage.ServiceNotFound);
            
            serviceLayerRepository.Remove(service);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
