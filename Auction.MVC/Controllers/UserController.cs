namespace Auction.MVC.Controllers;

[Authorize]
public class UserController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        var result = await sender.Send(new GetUserProfileCommand(userId));

        return result.Match(
            onSuccess: value => View(result.Value),
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.IdNotFound)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );

    }

    [HttpGet]
    public IActionResult AdminDashboard()
    {
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllUsersQuery());

        return result.Match(
            onSuccess: value => View(result.Value),
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.NoContent)
                    return NoContent();

                return BadRequest();
            }
        );
    }


    [HttpGet]
    public IActionResult GetById()
    {
        return View();
    }

    public async Task<IActionResult> GetById(long id)
    {
        var result = await sender.Send(new GetByIdUserQuery(id));

        return result.Match(
            onSuccess: value => View(result.Value),
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.IdNotFound)
                    return BadRequest(error.Message);

                else return BadRequest();
            }
        );
    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserDTO userDTO)
    {
        int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        var result = await sender.Send(new UpdateUserCommand(userDTO, userId));

        return result.Match(
            onSuccess: value => RedirectToAction("Profile"),
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.IdNotFound)
                    return NotFound(error.Message);

                if (error.Code == UserErrorCodes.EmailIsNotUnique)
                    return BadRequest(error.Message);

                if (error.Code == UserErrorMessages.NickNameIsNotUnique)
                    return BadRequest(error.Message);

                return BadRequest();

            }
        );

    }

    [HttpGet]
    public IActionResult Delete()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await sender.Send(new DeleteUserCommand(id));

        return result.Match(
            onSuccess: value => RedirectToAction("AdminDashboard"),  /// обработать мол удаление прошло успешно туда сюда
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.IdNotFound)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }

    [HttpGet]

    [Authorize(Roles = "Admin")]
    public IActionResult ChangeRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangeRole(long id, UserRole role)
    {
        var result = await sender.Send(new UpdateUserRoleCommand(role, id));

        return result.Match(
            onSuccess: value => RedirectToAction("AdminDashboard"),
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.IdNotFound)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }
}