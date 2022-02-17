using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PhoneDirectory.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.ReportApplicationCore.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }


            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong:{ex.Message},stack trace:{ex.StackTrace}");
                await HandleExceptionAsync(context, ex, "InternalServerError");

            }

        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception, string message)
        {

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(Response<NoContent>.Fail(message, context.Response.StatusCode));

            await context.Response.WriteAsync(result);


        }

    }
}
