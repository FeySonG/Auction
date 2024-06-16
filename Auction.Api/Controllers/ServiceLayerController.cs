namespace Auction.Api.Controllers;

[ApiController]
[Route("api/services")]
public class ServiceLayerController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllServiceLayerQuery());
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }
    [HttpGet("by-name{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var result = await sender.Send(new GetByNameServiceLayerQuery(name));
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }
    [HttpGet("my-services")]
    public async Task<IActionResult> GetUserServices()
    {
        var result = await sender.Send(new GetUserServiceLayerQuery());
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await sender.Send(new GetByIdServiceQuery(id));
        return result.Match(
         onSuccess: value => Ok(result.Value),
         onFailure: error => BadRequest(error.Message));
    }

    [HttpPost] 
    public async Task<IActionResult> Create(CreateServiceLayerDTO dto)
    {
        var result = await sender.Send(new CreateServiceLayerCommand(dto));
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateServiceLayerDTO dto, long id)
    {
        var result = await sender.Send(new UpdateServiceLayerCommand(dto, id));
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await sender.Send(new DeleteServiceLayerCommand(id));
        return result.Match(
            onSuccess: value => NoContent(),
            onFailure: error => BadRequest(error.Message));
    }
}