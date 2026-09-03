using Lagom.Domain.WorkItems;

namespace Lagom.Infrastructure.Data.Repositories;

internal class EFWorkItemRepository(LagomDbContext context) : IWorkItemRepository
{
    private readonly LagomDbContext _context = context;

    public WorkItem? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<WorkItem> ListAll(DateOnly? startDate, DateOnly? endDate)
    {
        throw new NotImplementedException();
    }

    public WorkItem RegisterWorkItem(WorkItem workItem)
    {
        var newWorkItem = _context.WorkItems.Add(workItem);

        return newWorkItem.Entity;
    }
}
