namespace Auction.Application.Features.ProductAuctions.GetById;

public record GetByIdProductAuctionQuery(long Id) : IQuery<Result<GetProductAuctionDTO>>;