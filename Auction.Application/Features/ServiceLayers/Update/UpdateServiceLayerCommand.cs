using Auction.Application.Abstractions;
using Auction.Application.Contracts.Services;
using Auction.Domain.Result;

namespace Auction.Application.Features.ServiceLayers.Update
{
    public record UpdateServiceLayerCommand(UpdateServiceLayerDto Dto, string ServiceName) : ICommand<Result<ResponseServiceLayerDto>>;
}
