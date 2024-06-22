namespace Auction.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/services-auctions")]
public class ServiceAuctionController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllServiceAuctionQuery());
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await sender.Send(new GetByIdServiceAuctionQuery(id));
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceAuctionDTO dto)
    {
        var result = await sender.Send(new CreateServiceAuctionCommand(dto));
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpPut("{offeredPrice}")]
    public async Task<IActionResult> ChangeCurrentPrice(decimal offeredPrice, long lotId)
    {
        var result = await sender.Send(new ChangeCurrentPriceServiceAuctionCommand(offeredPrice, lotId));
        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error => BadRequest(error.Message));
    }

}