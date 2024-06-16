namespace Auction.Application.Features.ServiceAuctions.Create;

public record CreateServiceAuctionCommand(CreateServiceAuctionDTO Dto) : ICommand<Result<GetServiceAuctionDTO>>;