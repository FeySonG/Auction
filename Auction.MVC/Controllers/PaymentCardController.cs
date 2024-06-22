using Auction.Application.Errors.PaymentCard;

namespace Auction.MVC.Controllers;

[Authorize]
public class PaymentCardController(ISender sender) : Controller
{

    [HttpGet]
    public IActionResult Create()
    {
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentCardDTO cardDTO)
    {
        var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var result = await sender.Send(new CreatePaymentCardCommand(cardDTO, userId));

        return result.Match(
            onSuccess: value => RedirectToAction("Profile","User"),
            onFailure: error =>
            {
                if (error.Code == PaymentCardErrorCodes.AlreadyExist)
                    return BadRequest(error.Message);

                return BadRequest();
            });

    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }


    //public async Task<IActionResult> Update(UpdatePaymentCardDTO paymentCardDTO)
    //{
    //    var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    //    var result = await sender.Send(new UpdatePaymentCardCommand(paymentCardDTO, userId));

    //    return result.Match(
    //        onSuccess: value => RedirectToAction("Profile", "User"),
    //        onFailure: error =>
    //        {
    //            if (error.Code == PaymentCardErrorCodes.UserIdNotFound)
    //                return BadRequest(error.Message);

    //            return BadRequest();
    //        }
    //    );
    //}


    [HttpPost]
    public async Task<IActionResult> Delete()
    {
        var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var result = await sender.Send(new DeletePaymentCardCommand(userId));

        return result.Match(
            onSuccess: value => RedirectToAction("Profile", "User"),
            onFailure: error =>
            {
                if (error.Code == PaymentCardErrorCodes.IsNotExist)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }
}