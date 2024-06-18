namespace Auction.Application.Features.ServiceAuctions.GetAll;

public record GetAllServiceAuctionQuery : IQuery<Result<List<GetServiceAuctionDTO>>>;