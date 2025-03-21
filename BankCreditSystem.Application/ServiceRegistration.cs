using System.Reflection;
using BankCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankCreditSystem.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BankCreditSystem.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceRegistration).Assembly);
        services.AddMediatR(configuration => {
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IndividualCustomerBusinessRules>();

        return services;
    }
} 