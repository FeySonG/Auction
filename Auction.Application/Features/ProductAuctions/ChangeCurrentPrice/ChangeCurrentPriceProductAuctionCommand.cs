namespace Auction.Application.Features.ProductAuctions.ChangeCurrentPrice;

/// <summary>
/// Represents a command to change the current price of a product auction.
/// </summary>
public record ChangeCurrentPriceProductAuctionCommand(decimal CurrentPrice, long lotId) : ICommand<Result<GetProductAuctionDTO>>;
