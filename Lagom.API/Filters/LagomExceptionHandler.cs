using Lagom.Communication.Shared;
using Lagom.Exception.Base;
using Microsoft.AspNetCore.Diagnostics;

namespace Lagom.API.Filters;

public class LagomExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
    {
        var (statusCode, response) = exception switch
        {
            LagomValidationException lagomValidationException => (lagomValidationException.StatusCode, new ResponseErrors("Ocorreu um erro de validação", lagomValidationException.Errors)),
            LagomDomainException lagomDomainException => (lagomDomainException.StatusCode, new ResponseErrors(lagomDomainException.ErrorMessage)),
            _ => (StatusCodes.Status500InternalServerError, new ResponseErrors("Erro desconhecido"))
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}
