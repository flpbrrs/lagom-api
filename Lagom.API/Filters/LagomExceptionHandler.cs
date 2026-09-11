using Lagom.Communication.Shared;
using Lagom.Exception.Base;
using Microsoft.AspNetCore.Diagnostics;

namespace Lagom.API.Filters;

public class LagomExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
    {
        var (statusCode, response) = exception is LagomException lagomException
            ? (lagomException.StatusCode, new ResponseErrors(lagomException.Errors))
            : (StatusCodes.Status500InternalServerError, new ResponseErrors("Erro desconhecido"));

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}
