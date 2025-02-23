using BankCreditSystem.Application.Services.Repositories;
using BankCreditSystem.Domain.Entities;
namespace BankCreditSystem.Application.Services.Repositories;

public interface ICustomerRepository : IAsyncRepository<Customer, Guid>
{
} 