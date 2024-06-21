
namespace Auction.MVC.Controllers;

[AllowAnonymous]
public class HomeController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var response = await sender.Send(new GetAllProductQuery());

            ViewBag.ShowBanner = true;

            return response.Match(
               onSuccess: value => View("index", response.Value),
               onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [HttpGet("Shop")]
    public async Task<IActionResult> Shop()
    {
        try
        {
            var response = await sender.Send(new GetAllProductQuery());

            return response.Match(
               onSuccess: value => View("Shop", response.Value),
               onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }


    [HttpGet("Auction")]
    public async Task<IActionResult> Auction()
    {
        try
        {
            var response = await sender.Send(new GetAllProductQuery());

            return response.Match(
               onSuccess: value => View("Auction"),
               onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }
}