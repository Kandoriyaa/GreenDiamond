using GreenDiamond.Application.Common;
using Newtonsoft.Json;
using System.Net;

namespace GreenDiamond.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger
            )
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
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            string message = exception.Message;

            //Write Log Here
            switch (exception.Message)
            {
                case "401":
                    context.Response.StatusCode = 401;
                    var UnauthorizedResponse = JsonConvert.SerializeObject(new ErrorResponseDto()
                    {
                        success = false,
                        status = Int32.Parse(exception.Message),
                        message = "You Do Not Have Permission To Perform This Action"
                    });
                    await context.Response.WriteAsync(UnauthorizedResponse);
                    break;

                case "403":
                    context.Response.StatusCode = 403;
                    var UnauthorizedRes = JsonConvert.SerializeObject(new ErrorResponseDto()
                    {
                        success = false,
                        status = Int32.Parse(exception.Message),
                        message = "You Do Not Have Permission To Perform This Action"
                    });
                    await context.Response.WriteAsync(UnauthorizedRes);
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    var InternalServerErrorResponse = JsonConvert.SerializeObject(new ErrorResponseDto()
                    {
                        success = false,
                        status = context.Response.StatusCode,
                        message = "Internal Server Error from the custom middleware."
                    });
                    await context.Response.WriteAsync(InternalServerErrorResponse);
                    break;
            }
        }
    }
}