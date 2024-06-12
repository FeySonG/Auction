using Auction.Api.Extensions;
using Auction.Application.Contracts.Services;
using Auction.Application.Features.Products.GetAll;
using Auction.Application.Features.Service.Create;
using Auction.Application.Features.ServiceLayers.Delete;
using Auction.Application.Features.ServiceLayers.GetAll;
using Auction.Application.Features.ServiceLayers.GetByName;
using Auction.Application.Features.ServiceLayers.GetUserServices;
using Auction.Application.Features.ServiceLayers.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/ServiceLayers")]
    public class ServiceLayerController(ISender sender) : ControllerBase
    {
        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetAll()
        {
            var response = await sender.Send(new GetAllServiceLayerQuery());
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string serviceName)
        {
            var response = await sender.Send(new GetByNameServiceLayerQuery(serviceName));
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }
        [HttpGet("GetUserServices")]
        public async Task<IActionResult> GetUserServices()
        {
            var response = await sender.Send(new GetUserServiceLayerQuery());
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpPost("CreateService")] 
        public async Task<IActionResult> CreateService(CreateServiceLayerDto dto)
        {
            var response = await sender.Send(new CreateServiceLayerCommand(dto));
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpdateService(UpdateServiceLayerDto dto, long id)
        {
            var response = await sender.Send(new UpdateServiceLayerCommand(dto, id));
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteService(long id)
        {
            var response = await sender.Send(new DeleteServiceLayerCommand(id));
            return response.Match(
                onSuccess: value => NoContent(),
                onFailure: error => BadRequest(error.Message));
        }
    }
}
