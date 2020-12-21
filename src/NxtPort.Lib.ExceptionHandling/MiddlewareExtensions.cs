using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NxtPort.Lib.ExceptionHandling.InternalExtensions;
using NxtPort.Lib.Exceptions;

namespace NxtPort.Lib.ExceptionHandling
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseNxtPortExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            return app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var problemDetailsFactory = context.RequestServices?.GetRequiredService<ProblemDetailsFactory>();

                    if (problemDetailsFactory == null)
                    {
                        logger.LogError("Cannot find {factory} in {services}, using generic fallback exception.", nameof(ProblemDetailsFactory), nameof(context.RequestServices));

                        await context.Response.WriteFallbackExceptionAsync();

                        return;
                    }

                    switch (context.GetException())
                    {
                        case NxtPortHttpException exception:
                        {
                            logger.LogError("Handling a {exceptionType} of {urn}.", nameof(NxtPortHttpException), exception.Instance);

                            var statusCode = (int) exception.StatusCode;
                            context.Response.StatusCode = statusCode;

                            var problemDetail = problemDetailsFactory.CreateProblemDetails(context, statusCode, detail: exception.Detail, instance: exception.Instance);
                            await context.Response.WriteJsonAsync(problemDetail);

                            break;
                        }
                        case NxtPortException exception:
                        {
                            logger.LogError("Handling a {exceptionType} of {urn}.", nameof(NxtPortException), exception.Instance);

                            var problemDetail = problemDetailsFactory.CreateProblemDetails(context, title: exception.Title, detail: exception.Detail, instance: exception.Instance);
                            await context.Response.WriteJsonAsync(problemDetail);

                            break;
                        }
                        default:
                            logger.LogError("Handing an exception that is not from NxtPort.");

                            await context.Response.WriteJsonAsync(problemDetailsFactory.CreateProblemDetails(context));

                            break;
                    }
                });
            });
        }
    }
}