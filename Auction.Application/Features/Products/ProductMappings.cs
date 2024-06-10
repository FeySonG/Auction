using Auction.Application.Contracts.Products;
using Auction.Application.Contracts.Profucts;
using Auction.Domain.Models.Products;
using AutoMapper;

namespace Auction.Application.Features.Products
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResponseProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
