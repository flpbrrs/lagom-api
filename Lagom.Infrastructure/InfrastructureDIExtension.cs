using Lagom.Application.Shared;
using Lagom.Domain.Tasks;
using Lagom.Infrastructure.Data;
using Lagom.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lagom.Infrastructure;

public static class InfrastructureDIExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("URL");

        services.AddDbContext<LagomDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<ITaskRepository, EFTaskRepository>();
        services.AddScoped<IUnitOfWork, EFUnitOfWork>();
    }
}
