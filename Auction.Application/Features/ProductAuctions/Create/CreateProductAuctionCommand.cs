namespace Auction.Application.Features.ProductAuctions.Create;

public record CreateProductAuctionCommand(CreateProductAuctionDTO dto) : ICommand<Result<GetProductAuctionDTO>>;