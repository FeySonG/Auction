namespace Auction.MVC.Controllers;

[AllowAnonymous]
public class AuthController(ISender sender) : Controller
{
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registration(UserCreateDTO userDTO)
    {
        var response = await sender.Send(new RegistrUserCommand(userDTO));
        if (response != false) return RedirectToAction("Index", "Home");
        return BadRequest("email or nickname is not unique!");   //obrabotatb
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginDTO loginDTO)
    {
        var response = await sender.Send(new LoginUserQuery(loginDTO.Email, loginDTO.Password));
        if (response == null) return BadRequest("Wrong Email or Password");

        return RedirectToAction("Index", "Home");

    }



    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }
}
