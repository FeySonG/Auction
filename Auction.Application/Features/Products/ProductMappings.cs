namespace Auction.Application.Features.Products;

public class ProductMappings : Profile
{
    public ProductMappings()
    {
        CreateMap<Product, CreateProductDTO>().ReverseMap();
        CreateMap<Product, GetProductDTO>().ReverseMap();
        CreateMap<Product, UpdateProductDTO>().ReverseMap();
    }
}