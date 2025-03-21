using AutoMapper;
using BankCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using BankCreditSystem.Domain.Entities;

namespace BankCreditSystem.Application.Features.IndividualCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Command Mappings
        CreateMap<CreateIndividualCustomerCommandRequest, IndividualCustomer>();
        CreateMap<IndividualCustomer, CreateIndividualCustomerCommandResponse>();

        // Query Mappings
        CreateMap<IndividualCustomer, GetByIdIndividualCustomerQueryResponse>();
    }
} 