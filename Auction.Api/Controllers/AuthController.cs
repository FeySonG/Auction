using Auction.Application.Contracts.Users;
using Auction.Application.Services;
using Auction.Domain.Models.Users;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController(IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpPost("Registr")]
        public async Task<IActionResult> Register(UserCreateDto dto)
        {
            var user = mapper.Map<User>(dto);

            userRepository.Add(user);
            await unitOfWork.SaveChangesAsync();
            return Ok(dto);
        }

        [HttpPost("Login")]
        public Task<IActionResult> Login()
        {
            return null;
        }
    }
}
