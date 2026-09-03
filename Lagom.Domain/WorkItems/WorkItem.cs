namespace Lagom.Domain.WorkItems;

public class WorkItem
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    public int DurationInMinutes { get; set; } = 0;

    public bool IsCompleted { get; set; } = false;
}
