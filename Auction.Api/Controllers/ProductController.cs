using Auction.Api.Extensions;
using Auction.Application.Contracts.Products;
using Auction.Application.Features.Products.ChangeQuantity;
using Auction.Application.Features.Products.Create;
using Auction.Application.Features.Products.Delete;
using Auction.Application.Features.Products.GetAll;
using Auction.Application.Features.Products.GetById;
using Auction.Application.Features.Products.GetByName;
using Auction.Application.Features.Products.GetUserProduct;
using Auction.Application.Features.Products.Update;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto dto)
        {
            var response = await sender.Send(new CreateProductCommand(dto));
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error =>
                {
                    return BadRequest(error.Message);
                });
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await sender.Send(new GetAllProductQuery());
            return response.Match(
                onSuccess: value => Ok(response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpGet("GetByProductName")]
        public async Task<IActionResult> GetByProductName(string name)
        {
            var response = await sender.Send(new GetByNameProductQuery(name));
            return response.Match(
               onSuccess: value => Ok(response.Value),
               onFailure: error =>
               {
                   return BadRequest(error.Message);
               });
        }
        [HttpGet("GetUserProducts")]
        public async Task<IActionResult> GetUserProducts()
        {
            var response = await sender.Send(new GetUserProductQuery());
            return response.Match(
              onSuccess: value => Ok(response.Value),
              onFailure: error => BadRequest(error.Message));

        }

        [HttpPut("ChangeProduct")]
        public async Task<IActionResult> ChangeProduct(long id, UpdateProductDto dto)
        {
            var response = await sender.Send(new UpdateProductCommand(dto, id));
            return response.Match(
              onSuccess: value => Ok(response.Value),
              onFailure: error => BadRequest(error.Message));
        }

        [HttpPut("ChangeQuantity")]
        public async Task<IActionResult> ChangeQuantity(long id, long quantity)
        {
            var response = await sender.Send(new ChangeQuantityProductCommand(id, quantity));
            return response.Match(
              onSuccess: value => Ok(response.Value),
              onFailure: error => BadRequest(error.Message));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var response = await sender.Send(new DeleteProductCommand(id));
            return response.Match(
              onSuccess: value => NoContent(),
              onFailure: error => BadRequest(error.Message));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await sender.Send(new GetByIdProductQuery(id));

            return result.Match(
             onSuccess: value => Ok(result.Value),
             onFailure: error => BadRequest(error.Message));
        }

    }
}
