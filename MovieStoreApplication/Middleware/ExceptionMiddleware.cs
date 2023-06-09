using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MovieStoreApplication.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                httpContext.Response.ContentType = "application/json";

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                //  code : "500", "message": "hata", url:""

                var result = Newtonsoft.Json.JsonConvert.SerializeObject(new { code = httpContext.Response.StatusCode, message = "Error Occured", url = httpContext.Request.Path.Value });

                await httpContext.Response.WriteAsync(result);

            }
     
        }
    }
}
