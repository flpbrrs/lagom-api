using Lagom.Domain.WorkItems;
using Microsoft.EntityFrameworkCore;

namespace Lagom.Infrastructure.Data;

internal class LagomDbContext(DbContextOptions<LagomDbContext> options) : DbContext(options)
{
    public DbSet<WorkItem> WorkItems { get; set; } = null!;
}
