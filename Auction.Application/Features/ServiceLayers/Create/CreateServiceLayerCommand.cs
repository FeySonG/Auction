namespace Auction.Application.Features.Service.Create
{
    public record CreateServiceLayerCommand(CreateServiceLayerDto dto) : ICommand<Result<ResponseServiceLayerDto>>;

}
