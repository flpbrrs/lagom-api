using Lagom.Communication.Tasks;
using Lagom.Domain.Tasks;

namespace Lagom.Application.Tasks.UseCase;

public class FindTaskByIdUseCase(ITaskRepository taskRepository)
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public TaskResponse? Execute(int taskId)
    {
        var task = _taskRepository.GetById(taskId);

        if(task == null)
        {
            return null;
        }

        return task.ToTaskResponse();
    }
}