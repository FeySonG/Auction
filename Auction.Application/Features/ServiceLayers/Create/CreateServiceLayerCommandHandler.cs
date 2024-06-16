namespace Auction.Application.Features.ServiceLayers.Create;

internal class CreateServiceLayerCommandHandler(
    IServiceLayerRepository serviceLayerRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor accessor) 
    : ICommandHandler<CreateServiceLayerCommand, Result<GetServiceLayerDTO>>
{
    private readonly HttpContext _httpContext = accessor.HttpContext!;

    public async Task<Result<GetServiceLayerDTO>> Handle(CreateServiceLayerCommand request, CancellationToken cancellationToken)
    {
        var userId = long.TryParse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : default;

        var service = mapper.Map<ServiceLayer>(request.dto);

        service.UserId = userId;
        serviceLayerRepository.Add(service);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<GetServiceLayerDTO>(service);
    }
}