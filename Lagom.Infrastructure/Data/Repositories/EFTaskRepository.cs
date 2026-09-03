using Lagom.Domain.Tasks;
using Task = Lagom.Domain.Tasks.Task;

namespace Lagom.Infrastructure.Data.Repositories;

internal class EFTaskRepository(LagomDbContext context) : ITaskRepository
{
    private readonly LagomDbContext _context = context;

    public Task? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Task> ListAll(DateOnly? startDate, DateOnly? endDate)
    {
        throw new NotImplementedException();
    }

    public Task RegisterTask(Task task)
    {
        _context.Tasks.Add(task);
        
        return task;
    }
}
