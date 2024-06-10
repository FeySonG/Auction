namespace Auction.MVC.Controllers;

[Authorize]
public class UserController(ISender sender) : Controller
{
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
    public IActionResult Adminka()
    {
        return View();
    }



    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
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


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult GetUserById()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetUserById(long id)
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
    public IActionResult UpdateUser()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> UpdateUser(UserUpdateDTO userDTO)
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


    public IActionResult DeleteUser()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ActionName("DeleteUser")]
    public async Task<IActionResult> DeleteUserPost(long id)
    {
        var result = await sender.Send(new DeleteUserCommand(id));

        return result.Match(
            onSuccess: value => RedirectToAction("Adminka"),  /// обработать мол удаление прошло успешно туда сюда
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.IdNotFound)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }


    [Authorize(Roles = "Admin")]
    public IActionResult ChangeUserRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangeUserRole(long id, UserRole role)
    {
        var result = await sender.Send(new UpdateUserRoleCommand(role, id));

        return result.Match(
            onSuccess: value => RedirectToAction("Adminka"),
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.IdNotFound)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }
}

