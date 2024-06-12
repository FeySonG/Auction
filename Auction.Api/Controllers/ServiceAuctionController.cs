using Auction.Api.Extensions;
using Auction.Application.Contracts.ProductAuctions;
using Auction.Application.Contracts.ServiceAuctions;
using Auction.Application.Features.ProductAuctions.ChangeCurrentPrice;
using Auction.Application.Features.ProductAuctions.Create;
using Auction.Application.Features.ProductAuctions.GetAll;
using Auction.Application.Features.ProductAuctions.GetById;
using Auction.Application.Features.ServiceAuctions.ChangeCurrentPrice;
using Auction.Application.Features.ServiceAuctions.Create;
using Auction.Application.Features.ServiceAuctions.GetAll;
using Auction.Application.Features.ServiceAuctions.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/serviceAuctions")]
    public class ServiceAuctionController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllServiceAuctions()
        {
            var response = await sender.Send(new GetAllServiceAuctionQuery());
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdServiceAuction(long id)
        {
            var response = await sender.Send(new GetByIdServiceAuctionQuery(id));
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceAuction(CreateServiceAuctionDto dto)
        {
            var response = await sender.Send(new CreateServiceAuctionCommand(dto));
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpPut]
        public async Task<IActionResult> ChangeCurrentPrice(decimal offeredPrice, long lotId)
        {
            var response = await sender.Send(new ChangeCurrentPriceServiceAuctionCommand(offeredPrice, lotId));
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }
    }
}
