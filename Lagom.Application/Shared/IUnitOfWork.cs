namespace Lagom.Application.Shared;

public interface IUnitOfWork
{
    public void Commit();
}
