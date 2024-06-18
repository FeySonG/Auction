namespace Auction.Application.Features.Products.Delete;

internal class DeleteProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<DeleteProductCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.Id);
        if (product == null)
            return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

        productRepository.Remove(product);
        await unitOfWork.SaveChangesAsync();
        return true;
    }
}