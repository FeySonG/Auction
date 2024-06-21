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


        if (request.Dto.ProductName == null || request.Dto.ProductName == "string")
            request.Dto.ProductName = product.ProductName;

        if (request.Dto.Description == null || request.Dto.Description == "string")
            request.Dto.Description = product.Description;

        if (request.Dto.Category == null || request.Dto.Category == 0)
            request.Dto.Category = product.Category;

        if (request.Dto.Price == null)
            request.Dto.Price = product.Price;

        if (request.Dto.ImagePath == null || request.Dto.ImagePath == "string")
            request.Dto.ImagePath = product.ImagePath;

        if (request.Dto.Quantity == null || request.Dto.Quantity == 0)
            request.Dto.Quantity = product.Quantity;

        mapper.Map(request.Dto, product);

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<GetProductDTO>(product);
    }
}