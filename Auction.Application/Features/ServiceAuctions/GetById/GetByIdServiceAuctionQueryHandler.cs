namespace Auction.Application.Features.ServiceAuctions.GetById;

internal class GetByIdServiceAuctionQueryHandler(
    IServiceAuctionRepository serviceAuctionRepository,
    IMapper mapper) 
    : IQueryHandler<GetByIdServiceAuctionQuery, Result<GetServiceAuctionDTO>>
{
    public async Task<Result<GetServiceAuctionDTO>> Handle(GetByIdServiceAuctionQuery request, CancellationToken cancellationToken)
    {
        var auction = await serviceAuctionRepository.GetById(request.Id);
        if (auction == null)
            return new Error(
                ServiceAuctionErrorCode.ServiceAuctionIsNotFound,
                ServiceAuctionErrorMessage.ServiceAuctionIsNotFound);
        return mapper.Map<GetServiceAuctionDTO>(auction);
    }
}