namespace Auction.Application.Features.ServiceAuctions;

public class ServiceAuctionMappings : Profile
{
    public ServiceAuctionMappings()
    {
        CreateMap<ServiceAuction, GetServiceAuctionDTO>().ReverseMap();
        CreateMap<ServiceAuction, CreateServiceAuctionDTO>().ReverseMap();
    }
}