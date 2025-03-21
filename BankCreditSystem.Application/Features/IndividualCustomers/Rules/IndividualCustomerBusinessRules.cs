using BankCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankCreditSystem.Application.Services.Repositories;

namespace BankCreditSystem.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task NationalIdCannotBeDuplicatedWhenInserted(string nationalId)
    {
        var result = await _individualCustomerRepository.AnyAsync(b => b.NationalId == nationalId);
        if (result) throw new Exception(IndividualCustomerMessages.NationalIdExists);
    }

    public async Task IndividualCustomerShouldExistWhenRequested(Guid id)
    {
        var result = await _individualCustomerRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new Exception(IndividualCustomerMessages.NotFound);
    }
} 