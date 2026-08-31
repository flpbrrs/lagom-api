using Lagom.Domain.Tasks;
using Task = Lagom.Domain.Tasks.Task;

namespace Lagom.Infrastructure.Data.Repositories;

internal class TasksRepository : ITaskRepository
{
    private int _nextId = 4;
    private readonly List<Task> _tasks = [
            new() { Id = 1, Title = "Task 1 DI", DurationInMinutes = 60, IsCompleted = false },
            new() { Id = 2, Title = "Task 2 DI", Date = new DateOnly(2026, 8, 20), DurationInMinutes = 120, IsCompleted = true },
            new() { Id = 3, Title = "Task 3 DI", Date = new DateOnly(2026, 8, 25), DurationInMinutes = 30, IsCompleted = false }
        ];

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
        var filtered = _tasks.AsEnumerable();

        if (startDate.HasValue)
            filtered = filtered.Where(t => t.Date >= startDate.Value);

        if (endDate.HasValue)
            filtered = filtered.Where(t => t.Date <= endDate.Value);

        return filtered;
    }

    public Task RegisterTask(Task task)
    {
        task.Id = Interlocked.Increment(ref _nextId);
        _tasks.Add(task);

        return task;
    }
}
