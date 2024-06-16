namespace Auction.MVC.Controllers;

[AllowAnonymous]
public class AuthController(ISender sender) : Controller
{
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registration(CreateUserDTO userDTO)
    {
        var result = await sender.Send(new RegistrUserCommand(userDTO));
        return result.Match(
            onSuccess: value => RedirectToAction("Login"),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserDTO loginDTO)
    {
        var result = await sender.Send(new LoginUserQuery(loginDTO.Email, loginDTO.Password));

        return result.Match(
            onSuccess: value => RedirectToAction("Index", "Home"),
            onFailure: error => BadRequest(error.Message));

    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }
}