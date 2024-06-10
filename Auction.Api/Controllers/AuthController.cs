using Auction.Application.Contracts.Users;
using Auction.Application.Features.Users.Auth.Login;
using Auction.Application.Features.Users.Auth.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/auth")]
    public class AuthController(ISender sender) : ControllerBase
    {
        [HttpPost("registr")]
        public async Task<IActionResult> Registration(UserCreateDTO dto)
        {
           var response = await sender.Send(new RegistrUserCommand(dto));
            if (response != false) return Ok();
            return BadRequest("email or nickname is not unique!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var response = await sender.Send(new LoginUserQuery(email, password));
            if (response == null) return BadRequest("Wrong Email or Password");
            return Ok("Welcome!");
        }
      
    }
}
