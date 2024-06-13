namespace Auction.Application.Features.ProductAuctions
{
    public class ProductAuctionMappings : Profile
    {
        public ProductAuctionMappings()
        {
            CreateMap<ProductAuction, ResponseProductAuctionDto>().ReverseMap();
            CreateMap<ProductAuction, CreateProductAuctionDto>().ReverseMap();
        }
    }
}
