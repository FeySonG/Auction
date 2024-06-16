namespace Auction.Application.Features.ServiceLayers.GetByName;

public record GetByNameServiceLayerQuery(string ServiceName) : IQuery<Result<List<GetServiceLayerDTO>>>;