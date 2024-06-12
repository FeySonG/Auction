namespace Auction.Application.Features.ServiceLayers.GetUserServices
{
    public record GetUserServiceLayerQuery : IQuery<Result<List<ResponseServiceLayerDto>>>;
}
