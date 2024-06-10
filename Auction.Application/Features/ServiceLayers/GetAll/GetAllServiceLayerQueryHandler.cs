using Auction.Application.Abstractions;
using Auction.Application.Contracts.Services;
using Auction.Domain.Models.Services;
using Auction.Domain.Result;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.ServiceLayers.GetAll
{
    public class GetAllServiceLayerQueryHandler(IServiceLayerRepository serviceLayerRepository,
        IMapper mapper) 
        : IQueryHandler<GetAllServiceLayerQuery, Result<List<ResponseServiceLayerDto>>>
    {
        public async Task<Result<List<ResponseServiceLayerDto>>> Handle(GetAllServiceLayerQuery request, CancellationToken cancellationToken)
        {
            var serviceLayers = await serviceLayerRepository.GetAllAsync();
            if(serviceLayers == null) 
                return new Error(GlobalErrorCode.InternalServerError, GlobalErrorMessage.InternalServerError);
            return mapper.Map<List<ResponseServiceLayerDto>>(serviceLayers);
        }
    }
}
