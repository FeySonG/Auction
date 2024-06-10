using Auction.Application.Abstractions;
using Auction.Application.Services;
using Auction.Domain.Models.Services;
using Auction.Domain.Result;

namespace Auction.Application.Features.ServiceLayers.Delete
{
    public class DeleteServiceLayerCommandHandler(
        IServiceLayerRepository serviceLayerRepository,
        IUnitOfWork unitOfWork) 
        : ICommandHandler<DeleteServiceLayerCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteServiceLayerCommand request, CancellationToken cancellationToken)
        {
            var service = await serviceLayerRepository.GetByName(request.ServiceName);
            if (service == null)
                return new Error(ServiceLayerErrorCode.ServiceNotFound, ServiceLayerErrorMessage.ServiceNotFound);
            
            serviceLayerRepository.Remove(service);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
