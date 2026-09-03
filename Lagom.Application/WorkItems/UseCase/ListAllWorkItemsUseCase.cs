using Lagom.Communication.WorkItems;
using Lagom.Domain.WorkItems;

namespace Lagom.Application.WorkItems.UseCase;

public class ListAllWorkItemsUseCase(IWorkItemRepository workItemRepository)
{
    private readonly IWorkItemRepository _workItemRepository = workItemRepository;

    public IEnumerable<WorkItemResponse> Execute(DateOnly? startDate, DateOnly? endDate)
    {
        return _workItemRepository.ListAll(startDate, endDate).Select(workItem => workItem.ToWorkItemResponse());
    }
}
