namespace Auction.Application.Features.ProductAuctions.ChangeCurrentPrice;

public record ChangeCurrentPriceProductAuctionCommand(decimal CurrentPrice, long lotId) : ICommand<Result<GetProductAuctionDTO>>;