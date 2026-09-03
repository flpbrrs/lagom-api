using Lagom.Communication.WorkItems;
using Lagom.Domain.WorkItems;

namespace Lagom.Application.WorkItems;

public static class WorkItemMapper
{
    public static WorkItemResponse ToWorkItemResponse(this WorkItem workItem)
    {
        return new WorkItemResponse
        {
            Id = workItem.Id,
            Title = workItem.Title,
            Date = workItem.Date.ToString("dd/MM/yyyy"),
            Duration = TimeSpan.FromMinutes(workItem.DurationInMinutes).ToString(@"hh\hmm"),
            IsCompleted = workItem.IsCompleted
        };
    }

    public static WorkItem ToDomainWorkItem(this RegisterWorkItemRequest request)
    {
        return new WorkItem
        {
            Title = request.Title,
            Date = request.Date,
            DurationInMinutes = request.DurationInMinutes,
            IsCompleted = false
        };
    }
}
