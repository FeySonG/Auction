namespace Auction.Application.Features.Users.GetOwnedServices;

public record GetOwnedServicesQuery(int UserId) : IQuery<Result<List<GetServiceLayerDTO>>>;
