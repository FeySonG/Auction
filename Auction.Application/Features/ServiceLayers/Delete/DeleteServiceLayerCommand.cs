using Auction.Application.Abstractions;
using Auction.Domain.Result;

namespace Auction.Application.Features.ServiceLayers.Delete
{
    public record DeleteServiceLayerCommand(string ServiceName) : ICommand<Result<bool>>;
}
