using BankCreditSystem.Domain.Entities;
using BankCreditSystem.Core.Repositories;

namespace BankCreditSystem.Application.Services.Repositories;

public interface ICustomerRepository : IAsyncRepository<Customer, Guid>
{
} 