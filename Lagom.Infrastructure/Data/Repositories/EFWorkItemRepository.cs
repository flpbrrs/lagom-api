using Microsoft.EntityFrameworkCore;
using Lagom.Domain.WorkItems;

namespace Lagom.Infrastructure.Data.Repositories;

internal class EFWorkItemRepository(LagomDbContext context) : IWorkItemRepository
{
    private readonly LagomDbContext _context = context;

    public async Task<WorkItem> RegisterAsync(WorkItem workItem)
    {
        await _context.WorkItems.AddAsync(workItem);

        return workItem;
    }

    public async Task<WorkItem?> GetByIdAsync(int id)
    {
        return await _context.WorkItems
            .AsNoTracking()
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<IEnumerable<WorkItem>> ListAllAsync(DateOnly? startDate, DateOnly? endDate)
    {
        var result = await _context.WorkItems
            .Where(w => (!startDate.HasValue || w.Date >= startDate.Value)
                     && (!endDate.HasValue || w.Date <= endDate.Value))
            .AsNoTracking()
            .ToListAsync();

        return result;
    }
}
