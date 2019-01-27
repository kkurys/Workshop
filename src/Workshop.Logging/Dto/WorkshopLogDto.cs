using System;

namespace Workshop.Logging.Dto
{
    public class WorkshopLogDto
    {
        public Guid Id { get; set; }
        public DateTime Occurence { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}
