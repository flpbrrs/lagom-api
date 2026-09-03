using Lagom.Communication.WorkItems;
using Lagom.Domain.WorkItems;

namespace Lagom.Application.WorkItems.UseCase;

public class FindWorkItemByIdUseCase(IWorkItemRepository workItemRepository)
{
    private readonly IWorkItemRepository _workItemRepository = workItemRepository;

    public WorkItemResponse? Execute(int workItemId)
    {
        var workItem = _workItemRepository.GetById(workItemId);

        if(workItem == null)
        {
            return null;
        }

        return workItem.ToWorkItemResponse();
    }
}
