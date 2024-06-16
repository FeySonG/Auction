namespace Auction.Application.Features.ServiceLayers;

public class ServiceLayerMappings : Profile
{
    public ServiceLayerMappings() 
    {
         CreateMap<ServiceLayer, CreateServiceLayerDTO>().ReverseMap();
         CreateMap<ServiceLayer, GetServiceLayerDTO>().ReverseMap();
         CreateMap<ServiceLayer, UpdateServiceLayerDTO>().ReverseMap();
    }
}