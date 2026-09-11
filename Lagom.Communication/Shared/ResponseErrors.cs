namespace Lagom.Communication.Shared;

public class ResponseErrors(IReadOnlyDictionary<string, List<string>> errors)
{
    public IReadOnlyDictionary<string, List<string>> Errors { get; } = errors;

    public ResponseErrors(string error) : this(new Dictionary<string, List<string>> { [string.Empty] = [error] }) { }
}
