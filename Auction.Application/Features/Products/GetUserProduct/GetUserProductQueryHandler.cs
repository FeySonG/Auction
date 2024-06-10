using Auction.Application.Abstractions;
using Auction.Application.Contracts.Products;
using Auction.Application.Services;
using Auction.Domain.Models.Products;
using Auction.Domain.Result;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Auction.Application.Features.Products.GetUserProduct
{
    public class GetUserProductQueryHandler : IQueryHandler<GetUserProductQuery, Result<List<ResponseProductDto>>>
    {
        private readonly HttpContext _httpContext;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetUserProductQueryHandler(IHttpContextAccessor accessor
        , IProductRepository productRepository
        , IMapper mapper)
        {
            if (accessor.HttpContext is null)
            {
                throw new ArgumentException(nameof(accessor.HttpContext));
            }
            _productRepository = productRepository;
            _mapper = mapper;
            _httpContext = accessor.HttpContext;
        }
        public async Task<Result<List<ResponseProductDto>>> Handle(GetUserProductQuery request, CancellationToken cancellationToken)
        {
            var userId = long.TryParse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : default;
            var userProducts = await _productRepository.GetUserProducts(userId);
            if (userProducts == null)
                return new Error(ProductErrorCode.UserHasNoProducts, ProductErrorMessage.UserHasNoProducts);

            return _mapper.Map<List<ResponseProductDto>>(userProducts);
        }
    }
}
