namespace Lagom.Application.Shared;

public interface IUnitOfWork
{
    public Task CommitAsync();
}
