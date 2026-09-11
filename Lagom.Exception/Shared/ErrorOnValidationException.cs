using Lagom.Exception.Base;

namespace Lagom.Exception.Shared;

public class ErrorOnValidationException(IReadOnlyDictionary<string, IEnumerable<string>> errors) : LagomValidationException(statusCode: 400, errors) { }
