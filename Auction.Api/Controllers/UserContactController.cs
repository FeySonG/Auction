using Auction.Application.Contracts.UserContacts;
using Auction.Application.Features.UserContacts.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Auction.Domain.Models.Result;
using Auction.Api.Extensions;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/user-contacts")]
    public class UserContactController(ISender sender) : ControllerBase
    {

        [HttpPut]
        public async Task<IActionResult> Update(UserContactUpdateDTO contactDTO)
        {
            Result<bool>? result = (Result<bool>?)await sender.Send(new UpdateUserContactCommand(contactDTO));
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
