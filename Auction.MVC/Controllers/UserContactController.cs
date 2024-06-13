﻿namespace Auction.MVC.Controllers;
public class UserContactController(ISender sender) : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(UserContactCreateDTO contactDTO)
    {
        var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var result = await sender.Send(new CreateUserContactCommand(contactDTO, userId));

        return result.Match
        (
            onSuccess: value => RedirectToAction("Profile"),
            onFailure: error =>
            {
                if (error.Code == ContactErrorCodes.AlreadyExist)
                    return BadRequest(error.Message);

                return BadRequest();
            }
        );
    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Update(UserContactUpdateDTO contactDTO)
    {
        var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var result = await sender.Send(new UpdateUserContactCommand(contactDTO, userId));

        return result.Match(
        onSuccess: value => RedirectToAction("Profile","User"),
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