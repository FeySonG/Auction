namespace Auction.Application.Features.Products.ChangeQuantity;

internal class ChangeQuantityProductHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) 
    : ICommandHandler<ChangeQuantityProductCommand, Result<GetProductDTO>>
{
    public async Task<Result<GetProductDTO>> Handle(ChangeQuantityProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.Id);
        if (product == null)
            return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

        product.Quantity = request.Quantity;

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<GetProductDTO>(product);
    }
}