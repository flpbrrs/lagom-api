using Lagom.Domain.Tasks;
using Lagom.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lagom.Infrastructure;

public static class InfrastructureDIExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITaskRepository, TasksRepository>();
    }
}
