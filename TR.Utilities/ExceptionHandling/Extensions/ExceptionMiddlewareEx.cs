using System.Text;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;
using TR.Utilities.ExceptionHandling.Models;

namespace TR.Utilities.ExceptionHandling.Extensions
{
    public static class ExceptionMiddlewareEx
    {
        public static void UseApiExceptionHandler(this IApplicationBuilder app/*, ILog logger*/)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        ///logger.Error($"Unhandled Exception: {contextFeature.Error.DeepException()}");
                        
                        // get string from byte array
                        await context.Response.WriteAsync(Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new ErrorDetails()
                        {
                            Status = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }))));
                    }
                });
            });
        }
    }
}
