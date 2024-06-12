namespace Auction.Application.Features.ProductAuctions.GetAll
{
    public class GetAllProductAuctionQueryHandler(
        IProductAuctionRepository productAuctionRepository,
        IMapper mapper) 
        : IQueryHandler<GetAllProductAuctionQuery, Result<List<ResponseProductAuctionDto>>>
    {
        public async Task<Result<List<ResponseProductAuctionDto>>> Handle(GetAllProductAuctionQuery request, CancellationToken cancellationToken)
        {
            var auctions = await productAuctionRepository.GetAllInqlude();
            if (auctions == null)
                return new Error(GlobalErrorCode.InternalServerError, GlobalErrorMessage.InternalServerError);
            return mapper.Map<List<ResponseProductAuctionDto>>(auctions);
        }
    }
}
