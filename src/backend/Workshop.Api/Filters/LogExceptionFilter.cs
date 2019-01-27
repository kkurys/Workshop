using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Workshop.Logging.Contracts;
using Workshop.Logging.Dto;

namespace Workshop.Api.Filters
{
    /// <summary>
    /// Filter used for logging 
    /// </summary>
    public class LogExceptionFilter : IActionFilter
    {
        private readonly ILoggingService _loggingService;

        public LogExceptionFilter(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null && !context.ExceptionHandled)
            {
                var log = new WorkshopLogDto()
                {
                    Occurence = DateTime.UtcNow,
                    StackTrace = context.Exception.StackTrace,
                    Exception = context.Exception.Message
                };

                _loggingService.Save(log).Wait();
            }
        }
    }
}
