namespace Auction.Application.Features.Products.Create;

internal class CreateProductCommandHandler(
    IHttpContextAccessor accessor,
    IProductRepository productRepository,
    IMapper _mapper,
    IUnitOfWork _unitOfWork)
    : ICommandHandler<CreateProductCommand, Result<CreateProductDTO>>
{
    private readonly HttpContext _httpContext = accessor.HttpContext!;
    public async Task<Result<CreateProductDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct =  _mapper.Map<Product>(request.Dto);

        if (long.TryParse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out long userId))
        {
            newProduct.UserId = userId;
        }

        if (request.Dto == null) 
            return new Error(ProductErrorCode.ProductIsNull, ProductErrorMessage.ProductIsNull);

         productRepository.Add(newProduct);
        await _unitOfWork.SaveChangesAsync();
        return request.Dto;
    }
}