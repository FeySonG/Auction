﻿using Auction.Application.Abstractions;
using Auction.Application.Contracts.Services;
using Auction.Application.Services;
using Auction.Domain.Models.Services;
using Auction.Domain.Result;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Auction.Application.Features.ServiceLayers.GetUserServices
{
    public class GetUserServiceLayerQueryHandler(
        IServiceLayerRepository serviceLayerRepository,
        IMapper mapper,
        IHttpContextAccessor accessor) 
        : IQueryHandler<GetUserServiceLayerQuery, Result<List<ResponseServiceLayerDto>>>
    {
        private readonly HttpContext _httpContext = accessor.HttpContext!;

        public async Task<Result<List<ResponseServiceLayerDto>>> Handle(GetUserServiceLayerQuery request, CancellationToken cancellationToken)
        {
            var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var service = await serviceLayerRepository.GetUserService(userId);
            if (service == null)
                return new Error(ServiceLayerErrorCode.ServiceNotFound, ServiceLayerErrorMessage.ServiceNotFound);
            return mapper.Map<List<ResponseServiceLayerDto>>(service);  

        }
    }
}