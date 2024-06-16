namespace Auction.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(ISender sender) : ControllerBase
{


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllProductQuery());
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var result = await sender.Send(new GetByNameProductQuery(name));
        return result.Match(
           onSuccess: value => Ok(result.Value),
           onFailure: error => BadRequest(error.Message));
    }

    [HttpGet("my-product")]
    public async Task<IActionResult> GetUserProducts()
    {
        var result = await sender.Send(new GetUserProductQuery());
        return result.Match(
          onSuccess: value => Ok(result.Value),
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

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDTO dto)
    {
        var result = await sender.Send(new CreateProductCommand(dto));
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateProductDTO dto)
    {
        var result = await sender.Send(new UpdateProductCommand(dto, id));
        return result.Match(
          onSuccess: value => Ok(result.Value),
          onFailure: error => BadRequest(error.Message));
    }

    [HttpPut("quantity/{id}")]
    public async Task<IActionResult> ChangeQuantity(long id, long quantity)
    {
        var result = await sender.Send(new ChangeQuantityProductCommand(id, quantity));
        return result.Match(
          onSuccess: value => Ok(result.Value),
          onFailure: error => BadRequest(error.Message));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await sender.Send(new DeleteProductCommand(id));
        return result.Match(
          onSuccess: value => NoContent(),
          onFailure: error => BadRequest(error.Message));
    }
}