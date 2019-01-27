using System.Collections.Generic;
using System.Threading.Tasks;
using Workshop.Logging.Dto;

namespace Workshop.Logging.Contracts
{
    public interface ILoggingService
    {
        Task Save(WorkshopLogDto log);
        Task<List<WorkshopLogDto>> GetLogs(int skip = 0, int take = 10);
    }
}
