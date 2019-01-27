using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Workshop.Logging.Contracts;

namespace Workshop.Api.Controllers
{
    public class LoggingController: WorkshopBaseController
    {
        private readonly ILoggingService _loggingService;

        public LoggingController(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        /// <summary>
        /// Returns "take" most recent logs while skipping skip * take entries.
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetLogs(int skip = 0, int take = 10)
        {
            var result = await _loggingService.GetLogs(skip, take);

            return Json(result);
        }
    }
}
