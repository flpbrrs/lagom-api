using Lagom.Application.Shared;
using Lagom.Communication.WorkItems;
using Lagom.Domain.WorkItems;

namespace Lagom.Application.WorkItems.UseCase;

public class RegisterNewWorkItemUseCase(IWorkItemRepository workItemRepository, IUnitOfWork unitOfWork)
{
    private readonly IWorkItemRepository _workItemRepository = workItemRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<WorkItemResponse> ExecuteAsync(RegisterWorkItemRequest workItem)
    {
        // TODO: Add data validation
        var newWorkItem = await _workItemRepository.RegisterAsync(workItem.ToDomainWorkItem());

        await _unitOfWork.CommitAsync();

        return newWorkItem.ToWorkItemResponse();
    }
}
