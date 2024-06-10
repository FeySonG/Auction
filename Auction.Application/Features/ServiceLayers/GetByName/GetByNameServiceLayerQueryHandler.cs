using Auction.Application.Abstractions;
using Auction.Application.Contracts.Services;
using Auction.Application.Features.Products;
using Auction.Application.Services;
using Auction.Domain.Models.Products;
using Auction.Domain.Models.Services;
using Auction.Domain.Result;
using AutoMapper;

namespace Auction.Application.Features.ServiceLayers.GetByName
{
    public class GetByNameServiceLayerQueryHandler(
        IServiceLayerRepository serviceLayerRepository,
        IMapper mapper)
        : IQueryHandler<GetByNameServiceLayerQuery, Result<List<ResponseServiceLayerDto>>>
    {
        public async Task<Result<List<ResponseServiceLayerDto>>> Handle(GetByNameServiceLayerQuery request, CancellationToken cancellationToken)
        {
            var service = await serviceLayerRepository.GetByName(request.ServiceName);
            if (service == null)
                return new Error(ServiceLayerErrorCode.ServiceNotFound, ServiceLayerErrorMessage.ServiceNotFound);
            return mapper.Map<List<ResponseServiceLayerDto>>(service);
        }
    }
}
