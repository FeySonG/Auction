namespace Auction.Application.Features.ServiceAuctions
{
    public class ServiceAuctionMappings : Profile
    {
        public ServiceAuctionMappings()
        {
            CreateMap<ServiceAuction, ResponseServiceAuctionDto>().ReverseMap();
            CreateMap<ServiceAuction, CreateServiceAuctionDto>().ReverseMap();
        }
    }
}
