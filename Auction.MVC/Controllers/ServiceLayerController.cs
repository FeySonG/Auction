namespace Auction.MVC.Controllers;

public class ServiceLayerController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await sender.Send(new GetAllServiceLayerQuery());
        return response.Match(
            onSuccess: value => Ok(response.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet]
    public async Task<IActionResult> GetByName(string serviceName)
    {
        var response = await sender.Send(new GetByNameServiceLayerQuery(serviceName));
        return response.Match(
            onSuccess: value => Ok(response.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet]
    public async Task<IActionResult> GetUserServices()
    {
        var response = await sender.Send(new GetUserServiceLayerQuery());
        return response.Match(
            onSuccess: value => Ok(response.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceLayerDTO dto)
    {
        var response = await sender.Send(new CreateServiceLayerCommand(dto));
        return response.Match(
            onSuccess: value => Ok(response.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateServiceLayerDTO dto, long id)
    {
        var response = await sender.Send(new UpdateServiceLayerCommand(dto, id));
        return response.Match(
            onSuccess: value => Ok(response.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var response = await sender.Send(new DeleteServiceLayerCommand(id));
        return response.Match(
            onSuccess: value => NoContent(),
            onFailure: error => BadRequest(error.Message));
    }
}