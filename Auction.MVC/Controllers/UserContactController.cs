using Auction.Application.Errors.User;
using Auction.Application.Errors.UserContact;

namespace Auction.MVC.Controllers;

[Authorize]
public class UserContactController(ISender sender) : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserContactDTO contactDTO)
    {
        try
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await sender.Send(new CreateUserContactCommand(contactDTO, userId));

            return result.Match
            (
                onSuccess: value => RedirectToAction("Profile", "User"),
                onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserContactDTO contactDTO)
    {
        try
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await sender.Send(new UpdateUserContactCommand(contactDTO, userId));

            return result.Match(
            onSuccess: value => RedirectToAction("Profile", "User"),
            onFailure: error => throw new Exception(error.Message));

        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> DeleteCurrentContact()
    {
        try
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var result = await sender.Send(new DeleteUserContactCommand(userId));

            return result.Match(
                onSuccess: value => RedirectToAction("Profile", "User"),
                onFailure: error => throw new Exception(error.Message));
      
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }
}