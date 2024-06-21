namespace Auction.MVC.Controllers;


public class ServiceLayerController(ISender sender, IWebHostEnvironment appEnvironment) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var response = await sender.Send(new GetAllServiceLayerQuery());
            return response.Match(
                onSuccess: value => View("ServiсesLayer", response.Value),
                onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetByName(string serviceName)
    {
        try
        {
            var response = await sender.Send(new GetByNameServiceLayerQuery(serviceName));
            return response.Match(
                onSuccess: value => View(response.Value),
                onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }


    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await sender.Send(new GetByIdServiceQuery(id));
            return result.Match(
             onSuccess: value => View("ServiceLayerDescription", result.Value),
             onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }


    public IActionResult Create()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceLayerDTO dto)
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
            var response = await sender.Send(new CreateServiceLayerCommand(dto));
            return response.Match(
                onSuccess: value => View("UserServicesLayerDescription", response.Value),
                onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Update(UpdateServiceLayerDTO dto, long id)
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
            var response = await sender.Send(new UpdateServiceLayerCommand(dto, id));
            return response.Match(
                onSuccess: value => View("UserServicesLayerDescription", response.Value),
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
            var response = await sender.Send(new DeleteServiceLayerCommand(id));

            var services = await sender.Send(new GetUserServiceLayerQuery());

            return response.Match(
                onSuccess: value => View("ServicesLayerUserShowcase", services.Value),
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
            var result = await sender.Send(new GetByIdServiceQuery(id));
            return result.Match(
             onSuccess: value => View("UserServicesLayerDescription", result.Value),
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
    public async Task<IActionResult> GetUserServices()
    {
        try
        {
            var response = await sender.Send(new GetUserServiceLayerQuery());
            return response.Match(
                onSuccess: value => View("ServicesLayerUserShowcase", response.Value),
                onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }
}