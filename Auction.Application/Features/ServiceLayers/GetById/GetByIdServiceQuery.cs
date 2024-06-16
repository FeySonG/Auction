namespace Auction.Application.Features.ServiceLayers.GetById;

public record GetByIdServiceQuery(int Id) : IQuery<Result<GetServiceLayerDTO>>;