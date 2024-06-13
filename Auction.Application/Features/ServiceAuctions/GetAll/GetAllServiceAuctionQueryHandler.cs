namespace Auction.Application.Features.ServiceAuctions.GetAll
{
    public class GetAllServiceAuctionQueryHandler(
        IServiceAuctionRepository serviceAuctionRepository,
        IMapper mapper) 
        : IQueryHandler<GetAllServiceAuctionQuery, Result<List<ResponseServiceAuctionDto>>>
    {
        public async Task<Result<List<ResponseServiceAuctionDto>>> Handle(GetAllServiceAuctionQuery request, CancellationToken cancellationToken)
        {
            var auctions = await serviceAuctionRepository.GetAllInqlude();
            if (auctions == null)
                return new Error(GlobalErrorCode.InternalServerError, GlobalErrorMessage.InternalServerError);
            return mapper.Map<List<ResponseServiceAuctionDto>>(auctions);
        }
    }
}
