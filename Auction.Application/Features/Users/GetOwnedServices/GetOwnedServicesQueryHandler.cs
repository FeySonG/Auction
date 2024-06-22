namespace Auction.Application.Features.Users.GetOwnedServices;

internal class GetOwnedServicesQueryHandler(IServiceLayerRepository  repository, IMapper mapper) : IQueryHandler<GetOwnedServicesQuery, Result<List<GetServiceLayerDTO>>>
{
    public async Task<Result<List<GetServiceLayerDTO>>> Handle(GetOwnedServicesQuery request, CancellationToken cancellationToken)
    {
        var ownedServices = await repository.GetUserOwnedServices(request.UserId);

        if (ownedServices.Count == 0)
            return new Error(ServiceLayerErrorCode.ServiceNoContent, ServiceLayerErrorMessage.UserHasNoServices);

        return mapper.Map<List<GetServiceLayerDTO>>(ownedServices);
    }
}