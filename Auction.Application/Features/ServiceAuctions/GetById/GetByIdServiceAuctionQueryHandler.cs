namespace Auction.Application.Features.ServiceAuctions.GetById
{
    public class GetByIdServiceAuctionQueryHandler(
        IServiceAuctionRepository serviceAuctionRepository,
        IMapper mapper) 
        : IQueryHandler<GetByIdServiceAuctionQuery, Result<ResponseServiceAuctionDto>>
    {
        public async Task<Result<ResponseServiceAuctionDto>> Handle(GetByIdServiceAuctionQuery request, CancellationToken cancellationToken)
        {
            var auction = await serviceAuctionRepository.GetById(request.Id);
            if (auction == null)
                return new Error(
                    ServiceAuctionErrorCode.ServiceAuctionIsNotFound,
                    ServiceAuctionErrorMessage.ServiceAuctionIsNotFound);
            return mapper.Map<ResponseServiceAuctionDto>(auction);
        }
    }
}
