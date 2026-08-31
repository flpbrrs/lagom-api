using Lagom.Communication.Tasks;
using Task = Lagom.Domain.Tasks.Task;

namespace Lagom.Application.Tasks;

public static class TaskMapper
{
    public static TaskResponse ToTaskResponse(this Task task)
    {
        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Date = task.Date.ToString("dd/MM/yyyy"),
            Duration = TimeSpan.FromMinutes(task.DurationInMinutes).ToString(@"hh\hmm"),
            IsCompleted = task.IsCompleted
        };
    }
}
