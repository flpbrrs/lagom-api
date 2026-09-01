using Lagom.Communication.Tasks;
using Lagom.Domain.Tasks;

namespace Lagom.Application.Tasks.UseCase;

public class RegisterNewTaskUseCase(ITaskRepository taskRepository)
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public TaskResponse Execute(RegisterTaskRequest task)
    {
        // TODO: Add data validation
        return _taskRepository.RegisterTask(task.ToDomainTask()).ToTaskResponse();
    }
}
