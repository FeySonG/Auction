namespace Auction.Application.Features.Service
{
    public class ServiceLayerMappings : Profile
    {
        public ServiceLayerMappings() 
        {
             CreateMap<ServiceLayer, CreateServiceLayerDto>().ReverseMap();
             CreateMap<ServiceLayer, ResponseServiceLayerDto>().ReverseMap();
             CreateMap<ServiceLayer, UpdateServiceLayerDto>().ReverseMap();
        }
        
    }
}
