using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BankCreditSystem.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceRegistration).Assembly);
        services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));

        return services;
    }
} 