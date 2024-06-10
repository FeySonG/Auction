
using Auction.Application.Abstractions;
using Auction.Application.Contracts.Services;
using Auction.Application.Services;
using Auction.Domain.Models.Services;
using Auction.Domain.Result;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Auction.Application.Features.Service.Create
{
    public class CreateServiceLayerCommandHandler(
        IServiceLayerRepository serviceLayerRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor accessor) 
        : ICommandHandler<CreateServiceLayerCommand, Result<ResponseServiceLayerDto>>
    {
        private readonly HttpContext _httpContext = accessor.HttpContext!;

        public async Task<Result<ResponseServiceLayerDto>> Handle(CreateServiceLayerCommand request, CancellationToken cancellationToken)
        {
            var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            
            var service = mapper.Map<ServiceLayer>(request.dto);

            service.Id = userId;
            serviceLayerRepository.Add(service);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<ResponseServiceLayerDto>(request.dto);
        }
    }
}
