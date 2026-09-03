namespace Lagom.Domain.WorkItems;

public interface IWorkItemRepository
{
    public IEnumerable<WorkItem> ListAll(DateOnly? startDate, DateOnly? endDate);
    public WorkItem? GetById(int id);
    public WorkItem RegisterWorkItem(WorkItem workItem);
}
