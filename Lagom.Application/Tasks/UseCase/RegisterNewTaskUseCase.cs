using Lagom.Application.Shared;
using Lagom.Communication.Tasks;
using Lagom.Domain.Tasks;

namespace Lagom.Application.Tasks.UseCase;

public class RegisterNewTaskUseCase(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
{
    private readonly ITaskRepository _taskRepository = taskRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public TaskResponse Execute(RegisterTaskRequest task)
    {
        // TODO: Add data validation
        var newTask = _taskRepository.RegisterTask(task.ToDomainTask());

        _unitOfWork.Commit();

        return newTask.ToTaskResponse();
    }
}
