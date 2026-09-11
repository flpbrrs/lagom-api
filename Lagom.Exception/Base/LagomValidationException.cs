namespace Lagom.Exception.Base;

public abstract class LagomValidationException(int statusCode, IReadOnlyDictionary<string, IEnumerable<string>> errors) : System.Exception
{
    public int StatusCode { get; } = statusCode;
    public IReadOnlyDictionary<string, IEnumerable<string>> Errors { get; } = errors;
}
