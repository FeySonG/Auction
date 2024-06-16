namespace Auction.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("index");
    }
}