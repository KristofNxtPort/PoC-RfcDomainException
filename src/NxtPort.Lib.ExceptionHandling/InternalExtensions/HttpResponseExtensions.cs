using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NxtPort.Lib.ExceptionHandling.InternalExtensions
{
    internal static class HttpResponseExtensions
    {
        public static async Task WriteJsonAsync(this HttpResponse response, object responseObject)
        {
            response.ContentType = "application/json; charset=utf-8";
            await response.WriteAsync(JsonSerializer.Serialize(responseObject));
        }
    }
}