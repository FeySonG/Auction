using Auction.Application.Contracts.UserContacts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Auction.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Auction.Application.Features.UserContacts.Update;
using Auction.Application.Features.UserContacts.Create;
using System.Security.Claims;
using Auction.Application.Features.UserContacts;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/user-contacts")]
    [Authorize]
    public class UserContactController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(UserContactCreateDTO contactDTO)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await sender.Send(new CreateUserContactCommand(contactDTO, userId));

            return result.Match
            (
                onSuccess: value => Ok(),
                onFailure: error =>
                {
                    if (error.Code == ContactErrorCodes.AlreadyExist)
                        return BadRequest(error.Message);

                    return BadRequest();
                }
            );
        }


        [HttpPut]
        public async Task<IActionResult> Update(UserContactUpdateDTO contactDTO)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await sender.Send(new UpdateUserContactCommand(contactDTO, userId));

            return result.Match(
            onSuccess: value => Ok(),
            onFailure: error =>
            {
                if (error.Code == ContactErrorCodes.IdNotFound)
                    return NotFound();

                else if (result == null)
                    return NoContent();

                return BadRequest();
            });
        }

    }
}
