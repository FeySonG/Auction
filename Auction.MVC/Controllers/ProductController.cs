using Auction.MVC.Filters;

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
            if (dto.ImagePath == null) { dto.ImagePath = string.Empty; }
            var response = await sender.Send(new CreateProductCommand(dto));
            return response.Match(
                onSuccess: value => View("UserProductDescription", response.Value),
                onFailure: error => throw new Exception(error.Message));

        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }

    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var response = await sender.Send(new GetAllProductQuery());
            return response.Match(
                onSuccess: value => View("Products", response.Value),
                onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [HttpGet("name")]
    public async Task<IActionResult> GetByName(string name)
    {
        try
        {
            var response = await sender.Send(new GetByNameProductQuery(name));
            return response.Match(
               onSuccess: value => View("Products", response.Value),
               onFailure: error => throw new Exception(error.Message));
              
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [Authorize]
    [HttpGet("user-products")]
    public async Task<IActionResult> GetUserProducts()
    {
        try
        {

            var response = await sender.Send(new GetUserProductQuery());
            return response.Match(
              onSuccess: value => View("UserShowcase", response.Value),
              onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    public IActionResult Update()
    {
        return View();
    }

    [Authorize]
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
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ChangeQuantity(long id, long quantity)
    {
        try
        {
            var response = await sender.Send(new ChangeQuantityProductCommand(id, quantity));
            return response.Match(
              onSuccess: value => View("UserProductDescription", response.Value),
              onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var response = await sender.Send(new DeleteProductCommand(id));

            var products = await sender.Send(new GetUserProductQuery());
            return response.Match(
              onSuccess: value => View("UserShowcase", products.Value),
              onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [HttpGet("product{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await sender.Send(new GetByIdProductQuery(id));

            return result.Match(
             onSuccess: value => View("ProductDescription", result.Value),
             onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetByIdUser(int id)
    {
        try
        {
            var result = await sender.Send(new GetByIdProductQuery(id));

            return result.Match(
             onSuccess: value => View("UserProductDescription", result.Value),
             onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }
}
