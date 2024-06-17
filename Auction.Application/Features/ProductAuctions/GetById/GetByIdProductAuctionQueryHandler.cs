using Auction.Application.Errors.ProductAuction;

namespace Auction.Application.Features.ProductAuctions.GetById;

internal class GetByIdProductAuctionQueryHandler(
    IProductAuctionRepository productAuctionRepository,
    IMapper mapper) 
    : IQueryHandler<GetByIdProductAuctionQuery, Result<GetProductAuctionDTO>>
{
    public async Task<Result<GetProductAuctionDTO>> Handle(GetByIdProductAuctionQuery request, CancellationToken cancellationToken)
    {
        var auction = await productAuctionRepository.GetById(request.Id);
        if (auction == null)
            return new Error(
                ProductAuctionErrorCode.ProductAuctionIsNotFound,
                ProductAuctionErrorMessage.ProductAuctionIsNotFound);
        return mapper.Map<GetProductAuctionDTO>(auction);
    }
}