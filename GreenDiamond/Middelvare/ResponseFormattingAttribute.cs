using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GreenDiamond.WebApi.Middleware
{
    public class ResponseFormattingAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var responseObject = objectResult.Value;
                var statusCode = objectResult.StatusCode ?? StatusCodes.Status200OK;
                var success = statusCode >= 200 && statusCode < 300;

                if (success && objectResult.StatusCode == (int)(HttpStatusCode.OK))
                {
                    if (responseObject is { })
                    {
                        var messageProperty = responseObject.GetType().GetProperty("Message");
                        var dataProperty = responseObject.GetType().GetProperty("Data");
                        if (messageProperty != null && dataProperty != null)
                        {
                            var formattedResponse = new
                            {
                                success,
                                status = statusCode,
                                message = (string)messageProperty.GetValue(responseObject),
                                data = (object)dataProperty.GetValue(responseObject),
                            };

                            context.Result = new ObjectResult(formattedResponse)
                            {
                                StatusCode = statusCode
                            };
                        }
                    }
                }
                else
                {
                    if (responseObject is { })
                    {
                        var messageProperty = responseObject.GetType().GetProperty("Message");
                        var formattedResponse = new
                        {
                            success = false,
                            status = objectResult.StatusCode,
                            message = (string)messageProperty.GetValue(responseObject),
                        };

                        context.Result = new ObjectResult(formattedResponse)
                        {
                            StatusCode = statusCode
                        };
                    }
                }
            }
        }
    }
}