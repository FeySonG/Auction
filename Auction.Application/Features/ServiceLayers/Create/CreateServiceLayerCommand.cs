using Auction.Application.Abstractions;
using Auction.Application.Contracts.Services;
using Auction.Domain.Result;

namespace Auction.Application.Features.Service.Create
{
    public record CreateServiceLayerCommand(CreateServiceLayerDto dto) : ICommand<Result<ResponseServiceLayerDto>>;

}
