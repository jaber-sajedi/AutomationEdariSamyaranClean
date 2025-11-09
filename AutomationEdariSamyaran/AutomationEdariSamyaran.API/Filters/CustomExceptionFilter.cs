using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutomationEdariSamyaran.API.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An error occurred in the controller.");

            var result = new ObjectResult(new
            {
                StatusCode = 500,
                Message = "An error occurred while processing your request.",
                Detailed = context.Exception.Message
            });

            context.Result = result;
            context.HttpContext.Response.StatusCode = 500;
        }
    }

}
