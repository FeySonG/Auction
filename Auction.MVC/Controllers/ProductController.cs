namespace Auction.MVC.Controllers;

public class ProductController(ISender sender , IWebHostEnvironment appEnvironment) : Controller
{
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDTO dto)
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


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await sender.Send(new GetAllProductQuery());
        return response.Match(
            onSuccess: value => View("Products", response.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet]
    public async Task<IActionResult> GetByName(string name)
    {
        var response = await sender.Send(new GetByNameProductQuery(name));
        return response.Match(
           onSuccess: value => View("Products", response.Value),
           onFailure: error =>
           {
               return BadRequest(error.Message);
           });
    }

    [HttpGet]
    public async Task<IActionResult> GetUserProducts()
    {
        var response = await sender.Send(new GetUserProductQuery());
        return response.Match(
          onSuccess: value => Ok(response.Value),
          onFailure: error => BadRequest(error.Message));

    }

    [HttpPost]
    public async Task<IActionResult> Update(long id, UpdateProductDTO dto)
    {
        var response = await sender.Send(new UpdateProductCommand(dto, id));
        return response.Match(
          onSuccess: value => Ok(response.Value),
          onFailure: error => BadRequest(error.Message));
    }

    [HttpPost]
    public async Task<IActionResult> ChangeQuantity(long id, long quantity)
    {
        var response = await sender.Send(new ChangeQuantityProductCommand(id, quantity));
        return response.Match(
          onSuccess: value => Ok(response.Value),
          onFailure: error => BadRequest(error.Message));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id)
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

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await sender.Send(new GetByIdProductQuery(id));

        return result.Match(
         onSuccess: value => View("ProductDescription", result.Value),
         onFailure: error => BadRequest(error.Message));
    }
}
