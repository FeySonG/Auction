namespace Auction.Application.Features.ProductAuctions.ChangeCurrentPrice
{
    public class ChangeCurrentPriceProductAuctionCommandHandler(
        IProductAuctionRepository productAuctionRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor accessor) 
        : ICommandHandler<ChangeCurrentPriceProductAuctionCommand, Result<ResponseProductAuctionDto>>
    {
        private readonly HttpContext _httpContext = accessor.HttpContext!;
        public async Task<Result<ResponseProductAuctionDto>> Handle(ChangeCurrentPriceProductAuctionCommand request, CancellationToken cancellationToken)
        {
            var userId = long.TryParse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : default;
            
            var auction = await productAuctionRepository.GetById(request.lotId);
            if (auction == null)
                return new Error(
                    ProductAuctionErrorCode.ProductAuctionIsNotFound,
                    ProductAuctionErrorMessage.ProductAuctionIsNotFound);
            if (request.CurrentPrice < auction.CurrentPrice)
                return new Error(
                    ProductAuctionErrorCode.PriceIsLess,
                    ProductAuctionErrorMessage.PriceIsLess);
            if (auction.EndTime > DateTime.UtcNow && auction.StartTime < DateTime.UtcNow)
            {
                auction.CurrentWinnerId = userId;
                auction.CurrentPrice = request.CurrentPrice;
                productAuctionRepository.Update(auction);
                await unitOfWork.SaveChangesAsync();
                return mapper.Map<ResponseProductAuctionDto>(auction);
            }
            return new Error(
                ProductAuctionErrorCode.OfferWasNotAccepted,
                ProductAuctionErrorMessage.OfferWasNotAccepted);

        }
    }
}
