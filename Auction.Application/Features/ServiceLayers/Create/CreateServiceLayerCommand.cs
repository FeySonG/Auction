namespace Auction.Application.Features.ServiceLayers.Create;

public record CreateServiceLayerCommand(CreateServiceLayerDTO dto) : ICommand<Result<GetServiceLayerDTO>>;