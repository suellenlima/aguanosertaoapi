using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Exceptions;
using AguaNoSertao.Domain.Helpers;
using Microsoft.AspNetCore.Diagnostics;

namespace AguaNoSertao.API
{
    public static class ExceptionHandler
    {
        public static WebApplication UseExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    IExceptionHandlerPathFeature? errorDetails = context.Features.Get<IExceptionHandlerPathFeature>();

                    if (errorDetails?.Error is ArgumentException || errorDetails?.Error is ArgumentNullException)
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    else if (errorDetails?.Error is SemAutorizacaoException)
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    else
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    context.Response.ContentType = "application/json";

                    Erro result = new();
                    result.StatusCode = context.Response.StatusCode;
                    result.Message = errorDetails?.Error.Message ?? string.Empty;
                    result.InnerMessage = errorDetails?.Error.InnerException?.Message ?? string.Empty;

                    await context.Response.WriteAsync(Util.SerializarJson(result));
                });
            });

            return app;
        }
    }
}
