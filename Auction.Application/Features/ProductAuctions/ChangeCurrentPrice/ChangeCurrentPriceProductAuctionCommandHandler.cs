namespace Auction.Application.Features.ProductAuctions.ChangeCurrentPrice;

/// <summary>
/// Command handler for changing the current price of a product auction.
/// </summary>
public class ChangeCurrentPriceProductAuctionCommandHandler
    : ICommandHandler<ChangeCurrentPriceProductAuctionCommand, Result<GetProductAuctionDTO>>
{
    private readonly IProductAuctionRepository productAuctionRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly HttpContext _httpContext;

    /// <summary>
    /// Constructor for <see cref="ChangeCurrentPriceProductAuctionCommandHandler"/>.
    /// </summary>
    /// <param name="productAuctionRepository">Repository for product auctions.</param>
    /// <param name="unitOfWork">Unit of work for database operations.</param>
    /// <param name="mapper">Mapper for mapping entities to DTOs.</param>
    /// <param name="accessor">Accessor for HTTP context.</param>
    public ChangeCurrentPriceProductAuctionCommandHandler(
        IProductAuctionRepository productAuctionRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor accessor)
    {
        this.productAuctionRepository = productAuctionRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        _httpContext = accessor.HttpContext ?? throw new ArgumentNullException(nameof(accessor));
    }

    /// <summary>
    /// Handles the command to change the current price of a product auction.
    /// </summary>
    /// <param name="request">Command request containing the lot ID and new current price.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Result containing either the updated product auction DTO or an error.</returns>
    public async Task<Result<GetProductAuctionDTO>> Handle(ChangeCurrentPriceProductAuctionCommand request, CancellationToken cancellationToken)
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
            return mapper.Map<GetProductAuctionDTO>(auction);
        }

        return new Error(
            ProductAuctionErrorCode.OfferWasNotAccepted,
            ProductAuctionErrorMessage.OfferWasNotAccepted);
    }
}
