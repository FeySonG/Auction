namespace Auction.MVC.Controllers;

[Authorize]
public class ServiceLayerController(ISender sender, IWebHostEnvironment appEnvironment) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await sender.Send(new GetAllServiceLayerQuery());
        return response.Match(
            onSuccess: value => View("ServiсesLayer", response.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet]
    public async Task<IActionResult> GetByName(string serviceName)
    {
        var response = await sender.Send(new GetByNameServiceLayerQuery(serviceName));
        return response.Match(
            onSuccess: value => View(response.Value),
            onFailure: error => BadRequest(error.Message));
    }


    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await sender.Send(new GetByIdServiceQuery(id));
        return result.Match(
         onSuccess: value => View("ServiceLayerDescription", result.Value),
         onFailure: error => BadRequest(error.Message));
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceLayerDTO dto)
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
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }


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
                onFailure: error => BadRequest(error.Message));
        }
        catch (Exception ex)
        {

            return View("Error", new { ErrorMessage = ex.Message });
        }
    }


    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        var response = await sender.Send(new DeleteServiceLayerCommand(id));

        var services = await sender.Send(new GetUserServiceLayerQuery());

        return response.Match(
            onSuccess: value => View("ServicesLayerUserShowcase", services.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet]
    public async Task<IActionResult> GetByIdUser(int id)
    {
        var result = await sender.Send(new GetByIdServiceQuery(id));
        return result.Match(
         onSuccess: value => View("UserServicesLayerDescription", result.Value),
         onFailure: error => BadRequest(error.Message));
    }

    [HttpGet]
    public async Task<IActionResult> GetUserServices()
    {
        var response = await sender.Send(new GetUserServiceLayerQuery());
        return response.Match(
            onSuccess: value => View("ServicesLayerUserShowcase", response.Value),
            onFailure: error => BadRequest(error.Message));
    }
}