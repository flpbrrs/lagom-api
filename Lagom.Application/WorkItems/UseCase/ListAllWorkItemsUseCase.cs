using Lagom.Communication.WorkItems;
using Lagom.Domain.WorkItems;

namespace Lagom.Application.WorkItems.UseCase;

public class ListAllWorkItemsUseCase(IWorkItemRepository workItemRepository)
{
    private readonly IWorkItemRepository _workItemRepository = workItemRepository;

    public async Task<IEnumerable<WorkItemResponse>> ExecuteAsync(DateOnly? startDate, DateOnly? endDate)
    {
        var workItems = await _workItemRepository.ListAllAsync(startDate, endDate);
        return workItems.Select(workItem => workItem.ToWorkItemResponse());
    }
}
