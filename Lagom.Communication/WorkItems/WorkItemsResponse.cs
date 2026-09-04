namespace Lagom.Communication.WorkItems;

public class WorkItemsResponse
{
    public IEnumerable<WorkItemResponse> WorkItems { get; set; } = [];
}
