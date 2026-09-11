using Lagom.Application.WorkItems.UseCase;
using Lagom.Application.WorkItems.UseCase.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Lagom.Application;

public static class ApplicationDIExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ListAllWorkItemsUseCase>();
        services.AddScoped<RegisterNewWorkItemUseCase>();
        services.AddScoped<FindWorkItemByIdUseCase>();
    }
}
