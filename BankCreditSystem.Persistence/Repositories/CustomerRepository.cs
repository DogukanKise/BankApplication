using BankCreditSystem.Application.Services.Repositories;
using BankCreditSystem.Core.Repositories;
using BankCreditSystem.Domain.Entities;
using BankCreditSystem.Persistence.Contexts;

namespace BankCreditSystem.Persistence.Repositories;

public class CustomerRepository : EfRepositoryBase<Customer, Guid, BaseDbContext>, ICustomerRepository
{
    public CustomerRepository(BaseDbContext context) : base(context)
    {
    }
} 