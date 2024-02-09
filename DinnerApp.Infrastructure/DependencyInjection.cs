using DinnerApp.Application.Common.Interfaces.Authentication;
using DinnerApp.Application.Common.Interfaces.Services;
using DinnerApp.Infrastructure.Authentication;
using DinnerApp.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
         services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
         services.AddSingleton<IDateTimeProvider, DateTimeProvider>(); 
         return services;
    }
}
