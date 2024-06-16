namespace Auction.Api.Controllers;

[ApiController]
[Route("api/payment-cards")]
[Authorize]
public class PaymentCardController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentCardDTO cardDTO)
    {
        var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var result = await sender.Send(new CreatePaymentCardCommand(cardDTO, userId));

        return result.Match(
            onSuccess: value => Ok(),
            onFailure: error =>
            {
                if (error.Code == PaymentCardErrorCodes.AlreadyExist)
                    return BadRequest(error.Message);

                return BadRequest();
            });
          
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdatePaymentCardDTO paymentCardDTO)
    {
        var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var result = await  sender.Send(new UpdatePaymentCardCommand(paymentCardDTO, userId));

        return result.Match(
            onSuccess: value => Ok(),
            onFailure: error =>
            {
                if(error.Code == PaymentCardErrorCodes.UserIdNotFound)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var result = await sender.Send(new DeletePaymentCardCommand(userId));

        return result.Match(
            onSuccess: value => NoContent(),
            onFailure: error =>
            {
                if (error.Code == PaymentCardErrorCodes.IsNotExist)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }
}