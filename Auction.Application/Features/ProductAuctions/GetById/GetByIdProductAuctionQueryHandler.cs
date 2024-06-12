namespace Auction.Application.Features.ProductAuctions.GetById
{
    public class GetByIdProductAuctionQueryHandler(
        IProductAuctionRepository productAuctionRepository,
        IMapper mapper) 
        : IQueryHandler<GetByIdProductAuctionQuery, Result<ResponseProductAuctionDto>>
    {
        public async Task<Result<ResponseProductAuctionDto>> Handle(GetByIdProductAuctionQuery request, CancellationToken cancellationToken)
        {
            var auction = await productAuctionRepository.GetById(request.Id);
            if (auction == null)
                return new Error(
                    ProductAuctionErrorCode.ProductAuctionIsNotFound,
                    ProductAuctionErrorMessage.ProductAuctionIsNotFound);
            return mapper.Map<ResponseProductAuctionDto>(auction);
        }
    }
}
