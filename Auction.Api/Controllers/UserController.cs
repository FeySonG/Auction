using Auction.Api.Extensions;
using Auction.Application.Contracts.Users;
using Auction.Application.Features.Users;
using Auction.Application.Features.Users.Delete;
using Auction.Application.Features.Users.GetAll;
using Auction.Application.Features.Users.GetById;
using Auction.Application.Features.Users.Update;
using Auction.Application.Features.Users.UpdateRole;
using Auction.Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController(ISender sender) : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await sender.Send(new GetAllUsersQuery());

            return result.Match(
                onSuccess: value => Ok(result.Value),
                onFailure: error =>
                {
                    if(error.Code == UserErrorCodes.NoContent)
                        return NoContent();

                    return BadRequest();
                }
            );
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var result = await sender.Send(new GetByIdUserQuery(id));
            
            return result.Match(
                onSuccess: value => Ok(result.Value),
                onFailure: error =>
                {
                    if (error.Code == UserErrorCodes.IdNotFound)
                        return BadRequest(error.Message);

                    else return BadRequest();
                }
            );
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO userDTO)
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var result = await  sender.Send(new UpdateUserCommand(userDTO, userId));

            return result.Match(
                onSuccess: value => Ok(),
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

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var result = await sender.Send(new DeleteUserCommand(id));

            return result.Match(
                onSuccess: value => NoContent(),
                onFailure: error =>
                {
                    if (error.Code == UserErrorCodes.IdNotFound)
                        return BadRequest(error.Message);

                     return BadRequest();
                }
            );
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("change-role/{id}")]
        public async Task<IActionResult> ChangeUserRole(long id, UserRole role)
        {
            var result = await sender.Send(new UpdateUserRoleCommand(role, id));

            return result.Match(
                onSuccess: value => Ok(),
                onFailure: error =>
                {
                    if (error.Code == UserErrorCodes.IdNotFound)
                        return BadRequest(error.Message);

                    return BadRequest();
                }
            );
        }
    }
}
