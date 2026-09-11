using Lagom.Exception.Base;

namespace Lagom.Exception.Shared;

public class ErrorOnValidationException(IReadOnlyDictionary<string, List<string>> errors) : LagomException
{
    public IReadOnlyDictionary<string, List<string>> Errors { get; } = errors;
}
