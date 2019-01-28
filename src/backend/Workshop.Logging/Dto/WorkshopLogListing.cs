using System.Collections.Generic;

namespace Workshop.Logging.Dto
{
    public class WorkshopLogListing
    {
        public int TotalCount { get; set; }
        public List<WorkshopLogDto> Logs { get; set; }
    }
}