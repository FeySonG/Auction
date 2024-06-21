namespace Auction.Application.Features.ProductAuctions.GetUserAuctions
{
	public class GetUserProductAuctionQueryHandler(
		IProductAuctionRepository productAuctionRepository,
		IMapper mapper,
		IHttpContextAccessor accessor)
		: IQueryHandler<GetUserProductAuctionQuery, Result<List<GetProductAuctionDTO>>>
	{
		private readonly HttpContext _httpContext = accessor.HttpContext!;
		public async Task<Result<List<GetProductAuctionDTO>>> Handle(GetUserProductAuctionQuery request, CancellationToken cancellationToken)
		{
			var userId = long.TryParse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : default;
			
			var auctions = await productAuctionRepository.GetUserAuctions(userId);
			if (auctions == null)
				return new Error(GlobalErrorCode.InternalServerError, GlobalErrorMessage.InternalServerError);

			return mapper.Map<List<GetProductAuctionDTO>>(auctions);
		}
	}
}
