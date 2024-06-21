namespace Auction.MVC.Controllers;

[AllowAnonymous]
public class AuthController(ISender sender) : Controller
{
    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registration(CreateUserDTO userDTO)
    {
        try
        {
            var result = await sender.Send(new RegistrUserCommand(userDTO));
            return result.Match(
                onSuccess: value => RedirectToAction("Login"),
                onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserDTO loginDTO)
    {
        try
        {
            var result = await sender.Send(new LoginUserQuery(loginDTO.Email, loginDTO.Password));

            return result.Match(
                onSuccess: value => RedirectToAction("Index", "Home"),
                onFailure: error => throw new Exception(error.Message));
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }

    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }
}