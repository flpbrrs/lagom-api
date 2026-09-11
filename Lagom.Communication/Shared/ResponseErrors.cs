using System.Text.Json.Serialization;

namespace Lagom.Communication.Shared;

public class ResponseErrors
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ErrorMessage { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyDictionary<string, IEnumerable<string>>? ErrorDetails { get; }

    public ResponseErrors(string errorMessage) => ErrorMessage = errorMessage;

    public ResponseErrors(IReadOnlyDictionary<string, IEnumerable<string>> errorDetails) => ErrorDetails = errorDetails;

    public ResponseErrors(string errorMessage, IReadOnlyDictionary<string, IEnumerable<string>> errorDetails)
    {
        ErrorMessage = errorMessage;
        ErrorDetails = errorDetails;
    }
}
