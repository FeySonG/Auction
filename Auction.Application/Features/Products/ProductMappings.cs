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
