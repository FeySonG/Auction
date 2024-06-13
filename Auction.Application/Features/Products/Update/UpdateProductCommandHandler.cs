namespace Auction.Application.Features.Products.Update
{
    public class UpdateProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) :
        ICommandHandler<UpdateProductCommand, Result<ResponseProductDto>>
    {
        public async Task<Result<ResponseProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetById(request.Id);
            if (product == null)
                return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

             mapper.Map(request.Dto, product);

            productRepository.Update(product);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<ResponseProductDto>(product);
        }
    }
}
