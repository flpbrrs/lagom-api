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
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<WorkItem>> ListAllAsync(DateOnly? startDate, DateOnly? endDate)
    {
        throw new NotImplementedException();
    }
}
