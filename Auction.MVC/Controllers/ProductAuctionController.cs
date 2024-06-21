using Auction.Application.Features.ProductAuctions.GetUserAuctions;
namespace Auction.Api.Controllers;


public class ProductAuctionController(ISender sender) : Controller
{
    [HttpGet("all-auctions")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await sender.Send(new GetAllProductAuctionQuery());
            return result.Match(
                onSuccess: value => View("Auctions", result.Value),
                onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [Authorize]
	[HttpGet("user-auctions")]
	public async Task<IActionResult> GetUserAuctions()
	{
		try
		{
			var result = await sender.Send(new GetUserProductAuctionQuery());
            return result.Match(
                onSuccess: value => View("ProductAuctionUser", result.Value),
                onFailure: error => throw new Exception(error.Message)
                );
		}
		catch (Exception ex)
		{
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
	}

	[HttpGet("auction{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        try
        {
            var result = await sender.Send(new GetByIdProductAuctionQuery(id));
            return result.Match(
                onSuccess: value => View("AuctionPage", result.Value),
                onFailure: error => throw new Exception(error.Message));

		}
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [HttpGet("auct-user{id}")]
    public async Task<IActionResult> GetByIdUser(long id)
    {
        try
        {
            var result = await sender.Send(new GetByIdProductAuctionQuery(id));
            return result.Match(
                onSuccess: value => View("UserAuctionPage", result.Value),
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

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductAuctionDTO dto)
    {
        try
        {
            var result = await sender.Send(new CreateProductAuctionCommand(dto));
            return result.Match(
                onSuccess: value => View("UserAuctionPage", result.Value),
                onFailure: error => throw new Exception(error.Message));

        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [HttpPost]
    public async Task<IActionResult> ChangeCurrentPrice(decimal offeredPrice, long lotId)
    {
        try
        {
            var result = await sender.Send(new ChangeCurrentPriceProductAuctionCommand(offeredPrice, lotId));
            return result.Match(
                onSuccess: value => View("AuctionPage",result.Value),
                onFailure: error => throw new Exception(error.Message));

        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }
}