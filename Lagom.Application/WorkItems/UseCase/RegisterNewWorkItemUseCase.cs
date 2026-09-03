using Lagom.Application.Shared;
using Lagom.Communication.WorkItems;
using Lagom.Domain.WorkItems;

namespace Lagom.Application.WorkItems.UseCase;

public class RegisterNewWorkItemUseCase(IWorkItemRepository workItemRepository, IUnitOfWork unitOfWork)
{
    private readonly IWorkItemRepository _workItemRepository = workItemRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public WorkItemResponse Execute(RegisterWorkItemRequest workItem)
    {
        // TODO: Add data validation
        var newWorkItem = _workItemRepository.RegisterWorkItem(workItem.ToDomainWorkItem());

        _unitOfWork.Commit();

        return newWorkItem.ToWorkItemResponse();
    }
}
