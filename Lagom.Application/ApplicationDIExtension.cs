using Lagom.Application.Tasks.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Lagom.Application;

public static class ApplicationDIExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ListAllTasksUseCase>();
        services.AddScoped<RegisterNewTaskUseCase>();
        services.AddScoped<FindTaskByIdUseCase>();
    }
}
