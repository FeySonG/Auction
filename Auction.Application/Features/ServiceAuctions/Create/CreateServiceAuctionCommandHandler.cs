namespace Auction.Application.Features.ServiceAuctions.Create;

internal class CreateServiceAuctionCommandHandler(
    IServiceAuctionRepository serviceAuctionRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor accessor,
    IServiceLayerRepository serviceLayerRepository) 
    : ICommandHandler<CreateServiceAuctionCommand, Result<GetServiceAuctionDTO>>
{
    private readonly HttpContext _httpContext = accessor.HttpContext!;

    public async Task<Result<GetServiceAuctionDTO>> Handle(CreateServiceAuctionCommand request, CancellationToken cancellationToken)
    {

        var sallerId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var auction = mapper.Map<ServiceAuction>(request.Dto);

        var service = await serviceLayerRepository.GetById(request.Dto.ServiceId);
        if (service == null)
            return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);
        auction.SallerId = sallerId;
        auction.Service = service;
        auction.EndTime = auction.StartTime.AddHours(request.Dto.Duration);

        serviceAuctionRepository.Add(auction);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<GetServiceAuctionDTO>(auction);
    }
}