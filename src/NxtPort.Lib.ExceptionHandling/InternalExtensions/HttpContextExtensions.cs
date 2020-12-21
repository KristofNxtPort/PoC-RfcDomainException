using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace NxtPort.Lib.ExceptionHandling.InternalExtensions
{
    internal static class HttpContextExtensions
    {
        public static Exception GetException(this HttpContext context)
        {
            var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
            return exceptionFeature.Error;
        }
    }
}