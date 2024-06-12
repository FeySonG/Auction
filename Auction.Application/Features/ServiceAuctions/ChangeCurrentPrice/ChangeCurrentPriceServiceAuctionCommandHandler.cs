namespace Auction.Application.Features.ServiceAuctions.ChangeCurrentPrice
{
    public class ChangeCurrentPriceServiceAuctionCommandHandler(
        IServiceAuctionRepository serviceAuctionRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor accessor) 
        : ICommandHandler<ChangeCurrentPriceServiceAuctionCommand, Result<ResponseServiceAuctionDto>>
    {
        private readonly HttpContext _httpContext = accessor.HttpContext!;
        public async Task<Result<ResponseServiceAuctionDto>> Handle(ChangeCurrentPriceServiceAuctionCommand request, CancellationToken cancellationToken)
        {
            var userId = long.TryParse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : default;

            var auction = await serviceAuctionRepository.GetById(request.lotId);
            if (auction == null)
                return new Error(
                    ServiceAuctionErrorCode.ServiceAuctionIsNotFound,
                    ServiceAuctionErrorMessage.ServiceAuctionIsNotFound);
            if (request.CurrentPrice < auction.CurrentPrice)
                return new Error(
                    ServiceAuctionErrorCode.PriceIsLess,
                    ServiceAuctionErrorMessage.PriceIsLess);
            if (auction.EndTime > DateTime.UtcNow && auction.StartTime < DateTime.UtcNow)
            {
                auction.CurrentWinnerId = userId;
                auction.CurrentPrice = request.CurrentPrice;
                serviceAuctionRepository.Update(auction);
                await unitOfWork.SaveChangesAsync();
                return mapper.Map<ResponseServiceAuctionDto>(auction);
            }
            return new Error(
                ServiceAuctionErrorCode.OfferWasNotAccepted,
                ServiceAuctionErrorMessage.OfferWasNotAccepted);
        }
    }
}
