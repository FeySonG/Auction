using Auction.Application.Abstractions;
using Auction.Application.Contracts.Services;
using Auction.Domain.Result;

namespace Auction.Application.Features.ServiceLayers.GetUserServices
{
    public record GetUserServiceLayerQuery : IQuery<Result<List<ResponseServiceLayerDto>>>;
}
