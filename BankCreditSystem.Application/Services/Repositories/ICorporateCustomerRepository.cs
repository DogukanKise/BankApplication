using BankCreditSystem.Core.Repositories;
using BankCreditSystem.Domain.Entities;

namespace BankCreditSystem.Application.Services.Repositories;

public interface ICorporateCustomerRepository : IAsyncRepository<CorporateCustomer, Guid>
{
} 