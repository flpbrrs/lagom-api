using Lagom.Domain.Tasks;
using Task = Lagom.Domain.Tasks.Task;

namespace Lagom.Infrastructure.Data.Repositories;

internal class TasksRepository : ITaskRepository
{
    private int _nextId = 1;
    private readonly List<Task> _tasks = [];

    public Task? GetById(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if(task == null)
        {
            return null;
        }

        return task;
    }

    public IEnumerable<Task> ListAll(DateOnly? startDate, DateOnly? endDate)
    {
        if (startDate != null && endDate != null)
        {
            return _tasks.Where(t => t.Date >= startDate && t.Date <= endDate);
        }
        
        return _tasks;
    }

    public Task RegisterTask(Task task)
    {
        task.Id = Interlocked.Increment(ref _nextId);
        _tasks.Add(task);

        return task;
    }
}
