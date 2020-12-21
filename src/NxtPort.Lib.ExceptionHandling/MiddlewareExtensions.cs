using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using NxtPort.Lib.ExceptionHandling.InternalExtensions;
using NxtPort.Lib.Exceptions;

namespace NxtPort.Lib.ExceptionHandling
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseNxtPortExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var problemDetailsFactory = context.RequestServices?.GetRequiredService<ProblemDetailsFactory>();

                    if (problemDetailsFactory == null)
                    {
                        await context.Response.WriteFallbackExceptionAsync();
                        return;
                    }

                    switch (context.GetException())
                    {
                        case NxtPortHttpException exception:
                        {
                            context.Response.StatusCode = exception.StatusCode;

                            var problemDetail = problemDetailsFactory.CreateProblemDetails(context, exception.StatusCode, detail: exception.Detail, instance: exception.Instance);
                            await context.Response.WriteJsonAsync(problemDetail);

                            break;
                        }
                        case NxtPortException exception:
                        {
                            var problemDetail = problemDetailsFactory.CreateProblemDetails(context, title: exception.Title, detail: exception.Detail, instance: exception.Instance);
                            await context.Response.WriteJsonAsync(problemDetail);

                            break;
                        }
                        default:
                            await context.Response.WriteJsonAsync(problemDetailsFactory.CreateProblemDetails(context));

                            break;
                    }
                });
            });

            return app;
        }
    }
}