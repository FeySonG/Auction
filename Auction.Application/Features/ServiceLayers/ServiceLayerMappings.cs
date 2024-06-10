using AutoMapper;
using Auction.Domain.Models.Services;
using Auction.Application.Contracts.Services;

namespace Auction.Application.Features.Service
{
    public class ServiceLayerMappings : Profile
    {
        public ServiceLayerMappings() 
        {
             CreateMap<ServiceLayer, CreateServiceLayerDto>().ReverseMap();
        }
        
    }
}
