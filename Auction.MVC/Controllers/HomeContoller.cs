
namespace Auction.MVC.Controllers;

[AllowAnonymous]
public class HomeController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await sender.Send(new GetAllProductQuery());

        ViewBag.ShowBanner = true;

        return response.Match(
		   onSuccess: value => View("index", response.Value),
		   onFailure: error => BadRequest(error.Message));
	}

    [HttpGet("Shop")]
    public async Task<IActionResult> Shop()
    {
        var response = await sender.Send(new GetAllProductQuery());

        return response.Match(
           onSuccess: value => View("Shop", response.Value),
           onFailure: error => BadRequest(error.Message));
    }


	[HttpGet("Auction")]
	public async Task<IActionResult> Auction()
	{
		var response = await sender.Send(new GetAllProductQuery());

		return response.Match(
		   onSuccess: value => View("Auction"),
		   onFailure: error => BadRequest(error.Message));
	}
}