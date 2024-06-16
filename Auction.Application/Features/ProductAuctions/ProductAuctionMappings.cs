namespace Auction.Application.Features.ProductAuctions;

public class ProductAuctionMappings : Profile
{
    public ProductAuctionMappings()
    {
        CreateMap<ProductAuction, GetProductAuctionDTO>().ReverseMap();
        CreateMap<ProductAuction, CreateProductAuctionDTO>().ReverseMap();
    }
}