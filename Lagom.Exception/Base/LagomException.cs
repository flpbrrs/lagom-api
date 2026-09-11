namespace Lagom.Exception.Base;

public abstract class LagomException(int statusCode) : System.Exception
{
    public int StatusCode { get; } = statusCode;
}
