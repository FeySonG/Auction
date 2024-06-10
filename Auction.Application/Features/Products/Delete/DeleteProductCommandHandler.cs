using Auction.Application.Abstractions;
using Auction.Application.Services;
using Auction.Domain.Models.Products;
using Auction.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.Products.Delete
{
    public class DeleteProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork) 
        : ICommandHandler<DeleteProductCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByName(request.productName);
            if (product == null)
                return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

            productRepository.Remove(product);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
