using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Data.Contracts;
using Workshop.Data.Models.Logging;
using Workshop.Logging.Contracts;
using Workshop.Logging.Dto;

namespace Workshop.Logging.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly IDataService _dataService;

        public LoggingService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task Save(WorkshopLogDto logDto)
        {
            var log = Mapper.Map<WorkshopLog>(logDto);

            await _dataService.GetSet<WorkshopLog>().AddAsync(log);

            await _dataService.SaveDbAsync();
        }

        public async Task<WorkshopLogListing> GetLogs(int skip = 0, int take = 10)
        {
            var logs = 
                _dataService.GetSet<WorkshopLog>()
                .OrderByDescending(x => x.Occurence);

            var result = new WorkshopLogListing
            {
                TotalCount = logs.Count(),
                Logs = await logs.Skip(skip * take)
                        .Take(take)
                        .Select(x => Mapper.Map<WorkshopLogDto>(x))
                        .ToListAsync()
            };

            return result;
        }
    }
}
