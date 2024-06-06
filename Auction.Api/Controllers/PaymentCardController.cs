using Auction.Api.Extensions;
using Auction.Application.Contracts.PaymentCards;
using Auction.Application.Features.PaymentCards;
using Auction.Application.Features.PaymentCards.Create;
using Auction.Application.Features.PaymentCards.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Auction.Api.Controllers
{
    [ApiController]
    [Route("api/payment-cards")]
    [Authorize]
    public class PaymentCardController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(PaymentCardCreateDTO cardDTO)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await sender.Send(new CreatePaymentCardCommand(cardDTO, userId));

            return result.Match(
                onSuccess: value => Ok(),
                onFailure: error =>
                {
                    if (error.Code == PaymentCardErrorCodes.AlreadyExist)
                        return BadRequest(error.Code);

                    return BadRequest();
                });
              
        }
        [HttpPut]
        public async Task<IActionResult> Update(PaymentCardUpdateDTO paymentCardDTO)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await  sender.Send(new UpdatePaymentCardCommand(paymentCardDTO, userId));

            return result.Match(
                onSuccess: value => Ok(),
                onFailure: error =>
                {
                    if(error.Code == "IdNotFound")
                        return BadRequest(error.Code);

                    return BadRequest();
                }
            );
        }
    }
}
