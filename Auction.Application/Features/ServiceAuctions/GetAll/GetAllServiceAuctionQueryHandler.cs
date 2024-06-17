using Auction.Application.Errors.Global;

namespace Auction.Application.Features.ServiceAuctions.GetAll;

internal class GetAllServiceAuctionQueryHandler(
    IServiceAuctionRepository serviceAuctionRepository,
    IMapper mapper) 
    : IQueryHandler<GetAllServiceAuctionQuery, Result<List<GetServiceAuctionDTO>>>
{
    public async Task<Result<List<GetServiceAuctionDTO>>> Handle(GetAllServiceAuctionQuery request, CancellationToken cancellationToken)
    {
        var auctions = await serviceAuctionRepository.GetAllInqlude();
        if (auctions == null)
            return new Error(GlobalErrorCode.InternalServerError, GlobalErrorMessage.InternalServerError);
        return mapper.Map<List<GetServiceAuctionDTO>>(auctions);
    }
}