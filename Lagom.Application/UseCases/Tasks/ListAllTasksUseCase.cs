using Lagom.Domain.Tasks;
using Task = Lagom.Domain.Tasks.Task;

namespace Lagom.Application.UseCases.Tasks;

public class ListAllTasksUseCase(ITaskRepository taskRepository)
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public IEnumerable<Task> Execute(DateOnly? startDate, DateOnly? endDate)
    {
        return _taskRepository.ListAll(startDate, endDate);
    }
}
