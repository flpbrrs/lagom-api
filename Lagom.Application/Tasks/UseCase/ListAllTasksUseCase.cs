using Lagom.Communication.Tasks;
using Lagom.Domain.Tasks;
using Task = Lagom.Domain.Tasks.Task;

namespace Lagom.Application.Tasks.UseCase;

public class ListAllTasksUseCase(ITaskRepository taskRepository)
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public IEnumerable<TaskResponse> Execute(DateOnly? startDate, DateOnly? endDate)
    {
        return _taskRepository.ListAll(startDate, endDate).Select(task => task.ToTaskResponse());
    }
}
