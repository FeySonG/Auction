using Auction.Application.Contracts.UserContacts;
using Auction.Application.Features.UserContacts.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Auction.Api.Extensions;
using Auction.Domain.Result;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/user-contacts")]
    public class UserContactController(ISender sender) : ControllerBase
    {
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(UserContactUpdateDTO contactDTO)
        {
            var result = (Result<bool>?)await sender.Send(new UpdateUserContactCommand(contactDTO));
            if (result == null) return NoContent();

            return result.Match(
            onSuccess: value => Ok(),
            onFailure: error =>
            {
                if (error.Code == "UserContact.IdNotFound")
                    return NotFound();

                return BadRequest(result.Error);
            });
        }
    }
}
