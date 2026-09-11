namespace Lagom.Exception.Base;

public abstract class LagomDomainException(int statusCode, string errorMessage) : System.Exception
{
    public int StatusCode { get; } = statusCode;
    public string ErrorMessage { get; } = errorMessage;
}
