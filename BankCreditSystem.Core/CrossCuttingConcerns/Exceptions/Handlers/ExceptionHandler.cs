using System.Reflection.Metadata;
using BankCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using ValidationException = FluentValidation.ValidationException;

namespace BankCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception)
    {
        if (exception is BusinessException businessException)
        {
            return HandleException(businessException);
        }
        if (exception is ValidationException validationException)
        {
            return HandleException(validationException);
        }
        if (exception is AuthorizationException authorizationException)
        {
            return HandleException(authorizationException);
        }

        return HandleException(exception);
    }

    protected abstract Task HandleException(ValidationException exception);
    protected abstract Task HandleException(AuthorizationException exception);
    protected abstract Task HandleException(NotFoundException exception);
    protected abstract Task HandleException(BusinessException exception);
    protected abstract Task HandleException(Exception exception);
} 