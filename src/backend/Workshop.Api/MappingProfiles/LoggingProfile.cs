using AutoMapper;
using Workshop.Data.Models.Logging;
using Workshop.Logging.Dto;

namespace Workshop.Api.MappingProfiles
{
    public class LoggingProfile : Profile
    {
        public LoggingProfile()
        {
            CreateMap<WorkshopLog, WorkshopLogDto>().ReverseMap();
        }
    }
}