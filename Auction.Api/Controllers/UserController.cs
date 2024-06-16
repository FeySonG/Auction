using Microsoft.AspNetCore.Authentication;

namespace Auction.Api.Controllers;

[ApiController]
[Route("api/users")]
[Authorize]
public class UserController(ISender sender) : ControllerBase
{
    [Authorize(Roles = "Admin, User")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllUsersQuery());

        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.NoContent)
                    return NoContent();

                return BadRequest();
            }
        );
    }

    [HttpGet("profile")]
    public async Task<IActionResult> Profile()
    {
        int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        var result = await sender.Send(new GetUserProfileCommand(userId));

        return result.Match(
            onSuccess: value => Ok(result.Value),
            onFailure: error =>
            {
                if (error.Code == UserErrorCodes.IdNotFound)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
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
    public async Task<IActionResult> Update(UpdateUserDTO userDTO)
    {
        int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        var result = await sender.Send(new UpdateUserCommand(userDTO, userId));

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

    [Authorize(Roles = "Admin, User")]
    [HttpPut("role/{id}")]
    public async Task<IActionResult> ChangeRole(long id, UserRole role)
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

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
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

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }
}