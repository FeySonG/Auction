using Auction.Application.Abstractions;
using Auction.Application.Contracts.Products;
using Auction.Application.Services;
using Auction.Domain.Models.Products;
using Auction.Domain.Result;
using AutoMapper;

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
            var product = await productRepository.GetByName(request.ProductName);
            if (product == null)
                return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

             mapper.Map(request.Dto, product);

            productRepository.Update(product);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<ResponseProductDto>(product);
        }
    }
}
