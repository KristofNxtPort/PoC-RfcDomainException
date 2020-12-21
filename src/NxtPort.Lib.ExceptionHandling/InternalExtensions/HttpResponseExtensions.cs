using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NxtPort.Lib.ExceptionHandling.InternalExtensions
{
    internal static class HttpResponseExtensions
    {
        public static async Task WriteJsonAsync(this HttpResponse response, object responseObject)
        {
            response.ContentType = "application/json; charset=utf-8";
            await response.WriteAsync(JsonSerializer.Serialize(responseObject));
        }

        public static async Task WriteFallbackExceptionAsync(this HttpResponse response)
        {
            await response.WriteJsonAsync(new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "An error occurred while processing your request.",
                Status = 500
            });
        }
    }
}