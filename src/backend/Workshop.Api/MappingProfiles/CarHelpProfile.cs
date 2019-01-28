using AutoMapper;
using Workshop.Api.ViewModels.CarHelpEntry;
using Workshop.CarHelp.Dto;
using Workshop.Data.Models.CarHelp;

namespace Workshop.Api.MappingProfiles
{
    public class CarHelpProfile: Profile
    {
        public CarHelpProfile()
        {
            CreateMap<CarHelpEntry, CarHelpEntryDto>()
                .ForMember(x => x.EmployeeName, y => y.MapFrom(x => $"{x.Employee.FirstName} {x.Employee.LastName}"))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(x => $"{x.EmployeeId.ToString()}"));

            CreateMap<CreateCarHelpRequestViewModel, CreateCarHelpEntryRequestDto>().ReverseMap();
            CreateMap<UpdateCarHelpRequestViewModel, UpdateCarHelpEntryRequestDto>().ReverseMap();
        }
    }
}
