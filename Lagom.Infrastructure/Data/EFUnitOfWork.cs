using Lagom.Application.Shared;

namespace Lagom.Infrastructure.Data;

internal class EFUnitOfWork(LagomDbContext context) : IUnitOfWork
{
    private readonly LagomDbContext _context = context;

    public void Commit() => _context.SaveChanges();
}
