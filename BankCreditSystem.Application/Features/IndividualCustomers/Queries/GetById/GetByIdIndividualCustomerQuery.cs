using AutoMapper;
using MediatR;
using BankCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankCreditSystem.Application.Services.Repositories;

namespace BankCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;

public class GetByIdIndividualCustomerQuery : IRequest<GetByIdIndividualCustomerQueryResponse>
{
    public Guid Id { get; set; }
    
}

public class GetByIdIndividualCustomerQueryHandler : IRequestHandler<GetByIdIndividualCustomerQuery, GetByIdIndividualCustomerQueryResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public GetByIdIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }
    public async Task<GetByIdIndividualCustomerQueryResponse> Handle(GetByIdIndividualCustomerQuery request,
        CancellationToken cancellationToken)
    {
        await _businessRules.IndividualCustomerShouldExistWhenRequested(request.Id);

        var individualCustomer = await _individualCustomerRepository.GetAsync(
            b => b.Id == request.Id,
            cancellationToken: cancellationToken);

        return _mapper.Map<GetByIdIndividualCustomerQueryResponse>(individualCustomer);
    }
}
