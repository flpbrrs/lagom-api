using Lagom.Application.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Lagom.Application;

public static class ApplicationDIExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ListAllTasksUseCase>();
    }
}
