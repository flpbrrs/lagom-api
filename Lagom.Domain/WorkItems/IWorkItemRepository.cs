namespace Lagom.Domain.WorkItems;

public interface IWorkItemRepository
{
    public Task<IEnumerable<WorkItem>> ListAllAsync(DateOnly? startDate, DateOnly? endDate);
    public Task<WorkItem?> GetByIdAsync(int id);
    public Task<WorkItem> RegisterAsync(WorkItem workItem);
}
