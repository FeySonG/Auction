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

        var serviceLayer = await serviceLayerRepository.GetById(request.Dto.ServiceId);
        if (serviceLayer == null)
            return new Error(ServiceLayerErrorCode.ServiceNotFound, ServiceLayerErrorMessage.ServiceNotFound);
        auction.SallerId = sallerId;
        auction.Service = serviceLayer;
        auction.EndTime = auction.StartTime.AddHours(3);

        serviceAuctionRepository.Add(auction);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<GetServiceAuctionDTO>(auction);
    }
}