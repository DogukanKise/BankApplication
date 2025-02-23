using BankCreditSystem.Application.Services.Repositories;
using BankCreditSystem.Core.Repositories;
using BankCreditSystem.Domain.Entities;
using BankCreditSystem.Persistence.Contexts;

namespace BankCreditSystem.Persistence.Repositories;

public class CorporateCustomerRepository : EfRepositoryBase<CorporateCustomer, Guid, BaseDbContext>, ICorporateCustomerRepository
{
    public CorporateCustomerRepository(BaseDbContext context) : base(context)
    {
    }
} 