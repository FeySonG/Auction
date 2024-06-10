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

namespace Auction.Application.Features.Products.GetByName
{
    public class GetByNameProductQueryHandler(IProductRepository productRepository, IMapper mapper) : IQueryHandler<GetByNameProductQuery, Result<ResponseProductDto>>
    {
        public async Task<Result<ResponseProductDto>> Handle(GetByNameProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByName(request.Name);
            if (product == null)
                return new Error(ProductErrorCode.ProductNotFound, ProductErrorMessage.ProductNotFound);
            return  mapper.Map<ResponseProductDto>(product);

        }
    }
}
