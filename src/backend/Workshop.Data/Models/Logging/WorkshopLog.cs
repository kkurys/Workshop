using System;

namespace Workshop.Data.Models.Logging
{
    public class WorkshopLog
    {
        public Guid Id { get; set; }
        public DateTime Occurence { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}