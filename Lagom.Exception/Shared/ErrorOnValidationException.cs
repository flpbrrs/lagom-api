using Lagom.Exception.Base;

namespace Lagom.Exception.Shared;

public class ErrorOnValidationException(List<string> errors) : LagomException(statusCode: 400, errors) { }
