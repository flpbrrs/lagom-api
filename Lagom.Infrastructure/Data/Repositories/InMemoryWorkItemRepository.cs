using Lagom.Domain.WorkItems;

namespace Lagom.Infrastructure.Data.Repositories;

internal class InMemoryWorkItemRepository : IWorkItemRepository
{
    private int _nextId = 4;
    private readonly List<WorkItem> _workItems = [
            new() { Id = 1, Title = "Task 1 DI", DurationInMinutes = 60, IsCompleted = false },
            new() { Id = 2, Title = "Task 2 DI", Date = new DateOnly(2026, 8, 20), DurationInMinutes = 120, IsCompleted = true },
            new() { Id = 3, Title = "Task 3 DI", Date = new DateOnly(2026, 8, 25), DurationInMinutes = 30, IsCompleted = false }
        ];

    public WorkItem? GetById(int id)
    {
        var workItem = _workItems.FirstOrDefault(w => w.Id == id);

        if(workItem == null)
        {
            return null;
        }

        return workItem;
    }

    public IEnumerable<WorkItem> ListAll(DateOnly? startDate, DateOnly? endDate)
    {
        var filtered = _workItems.AsEnumerable();

        if (startDate.HasValue)
            filtered = filtered.Where(w => w.Date >= startDate.Value);

        if (endDate.HasValue)
            filtered = filtered.Where(w => w.Date <= endDate.Value);

        return filtered;
    }

    public WorkItem RegisterWorkItem(WorkItem workItem)
    {
        workItem.Id = Interlocked.Increment(ref _nextId);
        _workItems.Add(workItem);

        return workItem;
    }
}
