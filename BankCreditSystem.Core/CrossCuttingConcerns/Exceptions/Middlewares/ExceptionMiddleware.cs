using BankCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;

namespace BankCreditSystem.Core.CrossCuttingConcerns.Exceptions.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _exceptionHandler;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
        _exceptionHandler = new HttpExceptionHandler();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await _exceptionHandler.HandleExceptionAsync(exception);
        }
    }
} 