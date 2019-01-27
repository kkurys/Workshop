using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using Workshop.Data.Contracts;
using Workshop.Data.Models.Logging;
using Workshop.Logging.Contracts;
using Workshop.Logging.Dto;

namespace Workshop.Filters
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
