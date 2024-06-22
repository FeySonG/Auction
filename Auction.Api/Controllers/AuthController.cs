namespace Auction.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/auth")]
public class AuthController(ISender sender) : ControllerBase
{
    [HttpPost("registration")]
    public async Task<IActionResult> Registration(CreateUserDTO dto)
    {
       var result = await sender.Send(new RegistrUserCommand(dto));

        return result.Match(
            onSuccess: value => Ok(),
            onFailure: error => BadRequest(error.Message));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDTO loginDto)
    {
        var result = await sender.Send(new LoginUserQuery(loginDto.Email, loginDto.Password));

        return result.Match(
            onSuccess: value => Ok("Welcome!"),
            onFailure: error => Unauthorized(error.Message));
    }
}