using Microsoft.EntityFrameworkCore;
using Task = Lagom.Domain.Tasks.Task;

namespace Lagom.Infrastructure.Data;

internal class LagomDbContext(DbContextOptions<LagomDbContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; } = null!;
}
