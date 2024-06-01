using Auction.Domain.Models.Result;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Extensions
{
    /// <summary>
    /// Provides extension methods for handling Result objects in ASP.NET Core.
    /// </summary>
    public static class ResultExtensions
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
}
