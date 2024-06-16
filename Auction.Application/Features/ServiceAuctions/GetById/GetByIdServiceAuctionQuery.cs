namespace Auction.Application.Features.ServiceAuctions.GetById;

public record GetByIdServiceAuctionQuery(long Id) : IQuery<Result<GetServiceAuctionDTO>>;