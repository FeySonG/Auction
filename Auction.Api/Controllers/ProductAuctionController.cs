namespace Auction.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/products-auctions")]
public class ProductAuctionController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllProductAuctionQuery());
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await sender.Send(new GetByIdProductAuctionQuery(id));
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductAuctionDTO dto)
    {
        var result = await sender.Send(new CreateProductAuctionCommand(dto));
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpPut]
    public async Task<IActionResult> ChangeCurrentPrice(decimal offeredPrice, long lotId)
    {
        var result = await sender.Send(new ChangeCurrentPriceProductAuctionCommand(offeredPrice, lotId));
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }
}