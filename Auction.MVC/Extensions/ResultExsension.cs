namespace Auction.MVC.Extensions;

public static class ResultExsension
{
    public static IActionResult Match<TValue>(
        this Result<TValue> result,
        Func<TValue?, IActionResult> onSuccess,
        Func<Error, IActionResult> onFailure)
    {
        if (result.IsSuccess)
            return onSuccess(result.Value);

        return onFailure(result.Error!);
    }
}

