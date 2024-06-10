using Auction.Application.Abstractions;
using Auction.Application.Contracts.Products;
using Auction.Application.Services;
using Auction.Domain.Models.Products;
using Auction.Domain.Result;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.Products.ChangeQuantity
{
    public class ChangeQuantityProductHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) 
        : ICommandHandler<ChangeQuantityProductCommand, Result<ResponseProductDto>>
    {
        public async Task<Result<ResponseProductDto>> Handle(ChangeQuantityProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByName(request.ProductName);
            if (product == null)
                return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);

            product.Quantity = request.Quantity;

            productRepository.Update(product);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<ResponseProductDto>(product);
        }
    }
}
