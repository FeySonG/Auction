using Auction.Application.Contracts.Users;
using Auction.Application.Features.Users.Auth.Login;
using Auction.Application.Features.Users.Auth.Registration;
using Auction.Application.Services;
using Auction.Domain.Models.Users;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Auction.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/Auth")]
    public class AuthController(ISender sender) : ControllerBase
    {
        [HttpPost("Registr")]
        public async Task<IActionResult> Register(UserCreateDto dto)
        {
           var response = await sender.Send(new RegistrUserCommand(dto));
            if (response != false) return Ok();
            return BadRequest("email or nickname is not unique!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var response = await sender.Send(new LoginUserQuery(email, password));
            if (response == null) return BadRequest("Wrong Email or Password");
            return Ok("Welcome!");
        }
    }
}
