using BankCreditSystem.Application.Services.Repositories;
using BankCreditSystem.Core.Repositories;
using BankCreditSystem.Domain.Entities;
using BankCreditSystem.Persistence.Contexts;

namespace BankCreditSystem.Persistence.Repositories;

public class IndividualCustomerRepository : EfRepositoryBase<IndividualCustomer, Guid, BaseDbContext>, IIndividualCustomerRepository
{
    public IndividualCustomerRepository(BaseDbContext context) : base(context)
    {
    }
} 