namespace Auction.Application.Features.ServiceAuctions.Create
{
    public record CreateServiceAuctionCommand(CreateServiceAuctionDto Dto) : ICommand<Result<ResponseServiceAuctionDto>>;
}
