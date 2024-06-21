using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Auction.Api.Controllers;

//[Authorize]
//[Route("product-auction")]
public class ProductAuctionController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await sender.Send(new GetAllProductAuctionQuery());
            return result.Match(
                onSuccess: value => View("Auctions", result.Value),
                onFailure: error => BadRequest(error.Message));
        }
        catch (Exception ex)
        {

            return View("Error", new { ErrorMessage = ex.Message });
        }
    }

    [HttpGet("auction{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        try
        {
            var result = await sender.Send(new GetByIdProductAuctionQuery(id));
            return result.Match(
                onSuccess: value => View("AuctionPage",result.Value),
                onFailure: error => BadRequest(error.Message));
        }
        catch (Exception ex)
        {

            return View("Error", new { ErrorMessage = ex.Message });
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductAuctionDTO dto)
    {
        try
        {
            var result = await sender.Send(new CreateProductAuctionCommand(dto));
            return result.Match(
                onSuccess: value => View("AuctionPage", result.Value),
                onFailure: error => BadRequest(error.Message));
        }
        catch (Exception ex)
        {

            return View("Error", new { ErrorMessage = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> ChangeCurrentPrice(decimal offeredPrice, long lotId)
    {
        try
        {
            var result = await sender.Send(new ChangeCurrentPriceProductAuctionCommand(offeredPrice, lotId));
            return result.Match(
                onSuccess: value => Ok(result.Value),
                onFailure: error => BadRequest(error.Message));
        }
        catch (Exception ex)
        {

            return View("Error", new { ErrorMessage = ex.Message });
        }
    }
}