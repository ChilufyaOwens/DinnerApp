using DinnerApp.Application.Common.Interfaces.Authentication;
using DinnerApp.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
         services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
         return services;
    }
}
