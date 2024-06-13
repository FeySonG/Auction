namespace Auction.Application.Features.ServiceAuctions.ChangeCurrentPrice
{
    public record ChangeCurrentPriceServiceAuctionCommand(decimal CurrentPrice, long lotId) : ICommand<Result<ResponseServiceAuctionDto>>;
}
