namespace Auction.MVC.Controllers;


public class ProductController(ISender sender, IWebHostEnvironment appEnvironment) : Controller
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
            string path = "/image/" + dto.UploadFile.FileName;
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await dto.UploadFile.CopyToAsync(fileStream);
            }
            dto.ImagePath = path;
        }
        dto.ImagePath ??= string.Empty;
        var response = await sender.Send(new CreateProductCommand(dto));
        return response.Match(
            onSuccess: value => View("UserProductDescription", response.Value),
            onFailure: error =>
            {
                return BadRequest(error.Message);
            });
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await sender.Send(new GetAllProductQuery());
        return response.Match(
            onSuccess: value => View("Products", response.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet("name")]
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

    [HttpGet("user-products")]
    public async Task<IActionResult> GetUserProducts()
    {
        var response = await sender.Send(new GetUserProductQuery());
        return response.Match(
          onSuccess: value => View("UserShowcase", response.Value),
          onFailure: error => BadRequest(error.Message));
    }


    public IActionResult Update()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(long id, UpdateProductDTO dto)
    {
        try
        {
            if (dto.UploadFile != null)
            {
                string path = "/image/" + dto.UploadFile.FileName;
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await dto.UploadFile.CopyToAsync(fileStream);
                }
                dto.ImagePath = path;
            }
            dto.ImagePath ??= string.Empty;
            var response = await sender.Send(new UpdateProductCommand(dto, id));
            return response.Match(
              onSuccess: value => View("UserProductDescription", response.Value),
              onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            
            return View("Error", new { ErrorMessage = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> ChangeQuantity(long id, long quantity)
    {
        var response = await sender.Send(new ChangeQuantityProductCommand(id, quantity));
        return response.Match(
          onSuccess: value => View("UserProductDescription", response.Value),
          onFailure: error => BadRequest(error.Message));
    }

    //public IActionResult Delete()
    //{
    //    return View();
    //}

    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        var response = await sender.Send(new DeleteProductCommand(id));

        var products = await sender.Send(new GetUserProductQuery());
        return response.Match(
          onSuccess: value => View("UserShowcase", products.Value),
          onFailure: error => BadRequest(error.Message));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await sender.Send(new GetByIdProductQuery(id));

        return result.Match(
         onSuccess: value => View("ProductDescription", result.Value),
         onFailure: error => BadRequest(error.Message));
    }

    [HttpGet]
    public async Task<IActionResult> GetByIdUser(int id)
    {
        var result = await sender.Send(new GetByIdProductQuery(id));

        return result.Match(
         onSuccess: value => View("UserProductDescription", result.Value),
         onFailure: error => BadRequest(error.Message));
    }
}
