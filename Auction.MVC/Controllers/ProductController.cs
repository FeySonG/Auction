using Auction.Application.Contracts.Products;
using Auction.Application.Features.Products.ChangeQuantity;
using Auction.Application.Features.Products.Create;
using Auction.Application.Features.Products.Delete;
using Auction.Application.Features.Products.GetAll;
using Auction.Application.Features.Products.GetById;
using Auction.Application.Features.Products.GetByName;
using Auction.Application.Features.Products.GetUserProduct;
using Auction.Application.Features.Products.Update;
using Auction.Domain.Result;

namespace Auction.MVC.Controllers
{
    public class ProductController(ISender sender , IWebHostEnvironment appEnvironment) : Controller
    {
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            if (dto.UploadFile != null)
            {
                string path = "/media/" + dto.UploadFile.FileName;
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await dto.UploadFile.CopyToAsync(fileStream);
                }
                dto.ImagePath = path;
            }
            var response = await sender.Send(new CreateProductCommand(dto));
            return response.Match(
                onSuccess: value => RedirectToAction("Product"),
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
                onSuccess: value => View("Product",response.Value),
                onFailure: error => BadRequest(error.Message));
        }

        [HttpGet("GetByProductName")]
        public async Task<IActionResult> GetByProductName(string name)
        {
            var response = await sender.Send(new GetByNameProductQuery(name));
            return response.Match(
               onSuccess: value => View("Product", response.Value),
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

        [HttpGet]
        public IActionResult GetById()
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await sender.Send(new GetByIdProductQuery(id));

            return result.Match(
             onSuccess: value => View("ProductDescription", result.Value),
             onFailure: error => BadRequest(error.Message));
        }
    }
}
