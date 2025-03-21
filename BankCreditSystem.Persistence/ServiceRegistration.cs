using BankCreditSystem.Application.Services.Repositories;
using BankCreditSystem.Core.Repositories;
using BankCreditSystem.Persistence.Contexts;
using BankCreditSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankCreditSystem.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
        services.AddScoped<ICorporateCustomerRepository,CorporateCustomerRepository>();
        return services;
    }
} 