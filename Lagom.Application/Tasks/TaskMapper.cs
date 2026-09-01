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

    public static Task ToDomainTask(this RegisterTaskRequest request)
    {
        return new Task
        {
            Title = request.Title,
            Date = request.Date,
            DurationInMinutes = request.DurationInMinutes,
            IsCompleted = false
        };
    }
}
