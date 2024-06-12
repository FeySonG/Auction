namespace Auction.Application.Features.ServiceLayers.Update
{
    public record UpdateServiceLayerCommand(UpdateServiceLayerDto Dto, long id) : ICommand<Result<ResponseServiceLayerDto>>;
}
