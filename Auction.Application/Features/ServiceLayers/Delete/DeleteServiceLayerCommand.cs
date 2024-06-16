namespace Auction.Application.Features.ServiceLayers.Delete;

public record DeleteServiceLayerCommand(long Id) : ICommand<Result<bool>>;