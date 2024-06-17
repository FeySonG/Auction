using Auction.Application.Errors.Global;

namespace Auction.Application.Features.ProductAuctions.GetAll;

internal class GetAllProductAuctionQueryHandler(
    IProductAuctionRepository productAuctionRepository,
    IMapper mapper) 
    : IQueryHandler<GetAllProductAuctionQuery, Result<List<GetProductAuctionDTO>>>
{
    public async Task<Result<List<GetProductAuctionDTO>>> Handle(GetAllProductAuctionQuery request, CancellationToken cancellationToken)
    {
        var auctions = await productAuctionRepository.GetAllInqlude();
        if (auctions == null)
            return new Error(GlobalErrorCode.InternalServerError, GlobalErrorMessage.InternalServerError);
        return mapper.Map<List<GetProductAuctionDTO>>(auctions);
    }
}