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
        try
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await sender.Send(new CreatePaymentCardCommand(cardDTO, userId));

            return result.Match(
                onSuccess: value => RedirectToAction("Profile", "User"),
                onFailure: error => throw new Exception(error.Message));

        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }

    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdatePaymentCardDTO paymentCardDTO)
    {
        try
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await sender.Send(new UpdatePaymentCardCommand(paymentCardDTO, userId));

            return result.Match(
                onSuccess: value => RedirectToAction("Profile", "User"),
                onFailure: error => throw new Exception(error.Message)
              
            );
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }


    [HttpPost]
    public async Task<IActionResult> Delete()
    {
        try
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await sender.Send(new DeletePaymentCardCommand(userId));

            return result.Match(
                onSuccess: value => RedirectToAction("Profile", "User"),
                onFailure: error => throw new Exception(error.Message)
           );
        }
        catch (Exception ex)
        {
            var model = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", model);
        }
    }
}