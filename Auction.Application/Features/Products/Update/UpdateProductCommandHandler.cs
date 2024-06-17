using Auction.Application.Errors.Product;

namespace Auction.Application.Features.Products.Update;

internal class UpdateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) :
    ICommandHandler<UpdateProductCommand, Result<GetProductDTO>>
{
    public async Task<Result<GetProductDTO>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.Id);
        if (product == null)
            return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

         mapper.Map(request.Dto, product);

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<GetProductDTO>(product);
    }
}