namespace BankCreditSystem.Domain.Entities;

public class CorporateCustomer : Customer
{
    public string CompanyName { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public string TaxOffice { get; set; } = default!;
    public string CompanyRegistrationNumber { get; set; } = default!;
    public decimal AnnualTurnover { get; set; }
    public int EmployeeCount { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public string? CommercialTitle { get; set; }
} 