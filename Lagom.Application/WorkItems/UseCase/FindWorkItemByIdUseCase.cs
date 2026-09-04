using Lagom.Communication.WorkItems;
using Lagom.Domain.WorkItems;

namespace Lagom.Application.WorkItems.UseCase;

public class FindWorkItemByIdUseCase(IWorkItemRepository workItemRepository)
{
    private readonly IWorkItemRepository _workItemRepository = workItemRepository;

    public async Task<WorkItemResponse?> ExecuteAsync(int workItemId)
    {
        var workItem = await _workItemRepository.GetByIdAsync(workItemId);

        if(workItem == null)
        {
            return null;
        }

        return workItem.ToWorkItemResponse();
    }
}
