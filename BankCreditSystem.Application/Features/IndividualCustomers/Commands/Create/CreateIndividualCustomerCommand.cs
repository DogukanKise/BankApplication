using AutoMapper;
using MediatR;
using BankCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankCreditSystem.Application.Services.Repositories;
using BankCreditSystem.Domain.Entities;

namespace BankCreditSystem.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerCommandResponse>
{
    public CreateIndividualCustomerCommandRequest Request { get; set; } = default!;

    public class CreateIndividualCustomerCommandHandler 
        : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerCommandResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(
            IIndividualCustomerRepository individualCustomerRepository, 
            IMapper mapper, 
            IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreateIndividualCustomerCommandResponse> Handle(
            CreateIndividualCustomerCommand request, 
            CancellationToken cancellationToken)
        {
            await _businessRules.NationalIdCannotBeDuplicatedWhenInserted(request.Request.NationalId);

            IndividualCustomer individualCustomer = _mapper.Map<IndividualCustomer>(request.Request);
            IndividualCustomer createdIndividualCustomer = await _individualCustomerRepository.AddAsync(individualCustomer);
            
            return _mapper.Map<CreateIndividualCustomerCommandResponse>(createdIndividualCustomer);
        }
    }
} 