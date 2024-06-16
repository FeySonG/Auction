namespace Auction.Application.Features.ServiceLayers.Update;

public record UpdateServiceLayerCommand(UpdateServiceLayerDTO Dto, long id) : ICommand<Result<GetServiceLayerDTO>>;