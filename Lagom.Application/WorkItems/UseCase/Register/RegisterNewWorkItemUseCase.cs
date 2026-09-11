using Lagom.Application.Shared;
using Lagom.Communication.WorkItems;
using Lagom.Domain.WorkItems;
using Lagom.Exception.Shared;

namespace Lagom.Application.WorkItems.UseCase.Register;

public class RegisterNewWorkItemUseCase(IWorkItemRepository workItemRepository, IUnitOfWork unitOfWork)
{
    private readonly IWorkItemRepository _workItemRepository = workItemRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<WorkItemResponse> ExecuteAsync(RegisterWorkItemRequest workItem)
    {
        Validate(workItem);

        var newWorkItem = await _workItemRepository.RegisterAsync(workItem.ToDomainWorkItem());

        await _unitOfWork.CommitAsync();

        return newWorkItem.ToWorkItemResponse();
    }

    private static void Validate(RegisterWorkItemRequest workItem)
    {
        var validationResult = new RegisterNewWorkItemValidator().Validate(workItem);

        if (validationResult.IsValid) return;

        throw new ErrorOnValidationException
            (
                validationResult.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToList())
            );
    }
}
