namespace Lagom.Exception.Base;

public abstract class LagomException(int statusCode, List<string> errors) : System.Exception
{
    public int StatusCode { get; } = statusCode;
    public List<string> Errors { get; } = errors;
}
