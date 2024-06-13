using Auction.Api.Extensions;
using Auction.Application.Contracts.ProductAuctions;
using Auction.Application.Features.ProductAuctions.ChangeCurrentPrice;
using Auction.Application.Features.ProductAuctions.Create;
using Auction.Application.Features.ProductAuctions.GetAll;
using Auction.Application.Features.ProductAuctions.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/productAuctions")]
    public class ProductAuctionController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProductAuctions()
        {
            var response = await sender.Send(new GetAllProductAuctionQuery());
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductAuction(long id)
        {
            var response = await sender.Send(new GetByIdProductAuctionQuery(id));
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAuction(CreateProductAuctionDto dto)
        {
            var response = await sender.Send(new CreateProductAuctionCommand(dto));
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpPut]
        public async Task<IActionResult> ChangeCurrentPrice(decimal offeredPrice, long lotId)
        {
            var response = await sender.Send(new ChangeCurrentPriceProductAuctionCommand(offeredPrice, lotId));
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }
    }
}
