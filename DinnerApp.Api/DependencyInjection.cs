using DinnerApp.Api.Common.Mapping;
using DinnerApp.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DinnerApp.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, DinnerProblemDerailsFactory>();
        services.AddMappings();
        return services;
    }
}
