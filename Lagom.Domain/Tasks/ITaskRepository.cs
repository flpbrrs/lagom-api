namespace Lagom.Domain.Tasks;

public interface ITaskRepository
{
    public IEnumerable<Task> ListAll(DateOnly? startDate, DateOnly? endDate);
    public Task? GetById(int id);
    public Task RegisterTask(Task task);
}
