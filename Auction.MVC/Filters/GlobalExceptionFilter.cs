﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace Auction.MVC.Filters
{
    //public class GlobalExceptionFilter : IExceptionFilter
    //{
    //    private readonly ILogger<GlobalExceptionFilter> _logger;

    //    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public void OnException(ExceptionContext context)
    //    {
    //        _logger.LogError(context.Exception, "An unhandled exception occurred.");

    //        var result = new ViewResult { ViewName = "Error" };
    //        result.ViewData["ErrorMessage"] = context.Exception.Message;
    //        context.Result = result;
    //        context.ExceptionHandled = true; // Указываем, что ошибка обработана
    //    }
    //}
}
