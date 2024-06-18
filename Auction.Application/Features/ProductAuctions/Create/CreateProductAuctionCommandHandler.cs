namespace Auction.Application.Features.ProductAuctions.Create;

internal class CreateProductAuctionCommandHandler(
    IProductAuctionRepository productAuctionRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IProductRepository productRepository,
    IHttpContextAccessor accessor)
    : ICommandHandler<CreateProductAuctionCommand, Result<GetProductAuctionDTO>>
{
    private readonly HttpContext _httpContext = accessor.HttpContext!;
    public async Task<Result<GetProductAuctionDTO>> Handle(CreateProductAuctionCommand request, CancellationToken cancellationToken)
    {
        var sallerId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var auction = mapper.Map<ProductAuction>(request.dto);

        var product = await productRepository.GetById(request.dto.ProductId);
        if (product == null)
            return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);
        auction.SallerId = sallerId;
        auction.Product = product;
        auction.EndTime = auction.StartTime.AddHours(3);   

        productAuctionRepository.Add(auction);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<GetProductAuctionDTO>(auction);
    }
}