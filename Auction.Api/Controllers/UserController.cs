using Auction.Application.Features.Users.Delete;
using Auction.Application.Features.Users.GetAll;
using Auction.Application.Features.Users.GetById;
using Auction.Application.Features.Users.UpdateRole;
using Auction.Domain.Enums.UserEnums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController(ISender sender) : ControllerBase
    {
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await sender.Send(new GetAllUsersQuery());

            return Ok(response);
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var response = await sender.Send(new GetByIdUserQuery(id));
            if (response == null) return BadRequest("UserNotFound");
            return Ok(response);
        }

        [HttpPut("UpdateUser")]
        public Task<IActionResult> UpdateUser()
        {
            return null;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var response = await sender.Send(new DeleteUserCommand(id));
            if (response == false) return BadRequest("UserNotFound");

            return NoContent();
        }

        [HttpPut("ChangeUserRole")]
        public async Task<IActionResult> ChangeUserRole(long id, UserRole role)
        {
            var response = await sender.Send(new UpdateUserRoleCommand(role, id));
            if (response == false) return BadRequest("UserNotFound");
            return Ok();
        }
    }
}
