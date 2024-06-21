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


    [HttpPost]
    public async Task<IActionResult> Create(CreateUserContactDTO contactDTO)
    {
        var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var result = await sender.Send(new CreateUserContactCommand(contactDTO, userId));

        return result.Match
        (
            onSuccess: value => RedirectToAction("Profile", "User"),
            onFailure: error =>
            {
                if (error.Code == ContactErrorCodes.AlreadyExist)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserContactDTO contactDTO)
    {
        var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var result = await sender.Send(new UpdateUserContactCommand(contactDTO, userId));

        return result.Match(
        onSuccess: value => RedirectToAction("Profile","User"),
        onFailure: error =>
        {
            if (error.Code == ContactErrorCodes.IdNotFound)
                return NotFound();

            else if (result == null)
                return NoContent();

            return BadRequest();
        });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCurrentContact()
    {
        int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        var result = await sender.Send(new DeleteUserContactCommand(userId));

        return result.Match(
            onSuccess: value => RedirectToAction("Profile", "User"),
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.IdNotFound)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }
}