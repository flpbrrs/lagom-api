using Lagom.Exception.Base;

namespace Lagom.Exception.Shared;

public class ErrorOnValidationException(IEnumerable<string> errors) : LagomException(statusCode: 400)
{
    public IEnumerable<string> Errors { get; } = errors;
}
