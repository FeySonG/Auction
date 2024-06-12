namespace Auction.Application.Features.ProductAuctions.Create
{
    public record CreateProductAuctionCommand(CreateProductAuctionDto dto) : ICommand<Result<ResponseProductAuctionDto>>;
}
