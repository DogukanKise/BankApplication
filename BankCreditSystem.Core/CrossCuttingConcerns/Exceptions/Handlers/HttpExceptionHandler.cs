using System.Text.Json;
using Microsoft.AspNetCore.Http;
using BankCreditSystem.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using BankCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;
using ValidationException = FluentValidation.ValidationException;

namespace BankCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse? _response;

    public HttpResponse Response
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }
    
    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        var details = new BusinessProblemDetails(exception.Message);
        return WriteAsJsonAsync(Response,details);
    }

    protected override Task HandleException(ValidationException exception)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        var details = new BusinessProblemDetails(exception.Message);
        return WriteAsJsonAsync(Response,details);
    }

    protected override Task HandleException(AuthorizationException exception)
    {
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        var details = new BusinessProblemDetails(exception.Message);
        return WriteAsJsonAsync(Response,details);
    }

    protected override Task HandleException(NotFoundException exception)
    {
        Response.StatusCode = StatusCodes.Status404NotFound;
        var details = new BusinessProblemDetails(exception.Message);
        return WriteAsJsonAsync(Response,details);
    }

    protected override Task HandleException(BusinessException exception)
    {
       Response.StatusCode = StatusCodes.Status500InternalServerError;
       var details = new BusinessProblemDetails(exception.Message);
       return WriteAsJsonAsync(Response,details);
    }
    
    private static Task WriteAsJsonAsync<T>(HttpResponse response, T value)
    {
        response.ContentType = "application/json";
        return JsonSerializer.SerializeAsync(response.Body, value);
    }
    
} 