namespace BankCreditSystem.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommandResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string NationalId { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
} 