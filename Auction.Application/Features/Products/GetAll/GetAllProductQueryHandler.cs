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

namespace Auction.Application.Features.Products.GetAll
{
    public class GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper) : IQueryHandler<GetAllProductQuery, Result<List<ResponseProductDto>>>
    {
        public async Task<Result<List<ResponseProductDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            var responseListProducts = mapper.Map<List<ResponseProductDto>>(products);
            if (responseListProducts == null) 
                return new Error(GlobalErrorCode.InternalServerError, GlobalErrorMessage.InternalServerError);

            return responseListProducts;
        }
    }
}
