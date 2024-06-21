using Auction.Application.Errors.User;

namespace Auction.MVC.Controllers;

[Authorize]
public class UserController(ISender sender) : Controller
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        try
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var result = await sender.Send(new GetUserProfileCommand(userId));

            return result.Match(
                onSuccess: value => View(result.Value),
                onFailure: error => throw new Exception(error.Message));


        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }

    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult AdminDashboard()
    {
        return View();
    }

    [Authorize]
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await sender.Send(new GetAllUsersQuery());

            return result.Match(
                onSuccess: value => View(result.Value),
                onFailure: error => throw new Exception(error.Message));


        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult GetById()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> GetById(long id)
    {
        try
        {
            var result = await sender.Send(new GetByIdUserQuery(id));

            return result.Match(
                onSuccess: value => View(result.Value),
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
    public async Task<IActionResult> Update(UpdateUserDTO userDTO)
    {
        try
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var result = await sender.Send(new UpdateUserCommand(userDTO, userId));

            return result.Match(
                onSuccess: value => RedirectToAction("Profile"),
                onFailure: error => throw new Exception(error.Message));


        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }

    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult Delete()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var result = await sender.Send(new DeleteUserCommand(id));

            return result.Match(
                onSuccess: value => RedirectToAction("AdminDashboard"),  /// обработать мол удаление прошло успешно туда сюда
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
    public async Task<IActionResult> DeleteAccount()
    {
        try
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var result = await sender.Send(new DeleteUserCommand(userId));

            return result.Match(
                onSuccess: value => RedirectToAction("Registration", "Auth"),
                onFailure: error => throw new Exception(error.Message));


        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult ChangeRole()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> ChangeRole(long id, UserRole role)
    {
        try
        {
            var result = await sender.Send(new UpdateUserRoleCommand(role, id));

            return result.Match(
                onSuccess: value => RedirectToAction("AdminDashboard"),
                onFailure: error => throw new Exception(error.Message));


        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }
}