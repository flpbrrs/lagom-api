namespace Lagom.Communication.Shared;

public class ResponseErrors(IEnumerable<string> errors)
{
    public IEnumerable<string> Errors { get; } = errors;

    public ResponseErrors(string error) : this([error]) { }
}
