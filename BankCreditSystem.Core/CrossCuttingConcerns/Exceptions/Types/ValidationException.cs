namespace BankCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }

}