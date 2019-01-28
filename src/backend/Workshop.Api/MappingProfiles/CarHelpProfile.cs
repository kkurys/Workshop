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
                .ForMember(x => x.EmployeeName,
                    y => y.MapFrom(x =>
                        !string.IsNullOrEmpty(x.Employee.FirstName) &&
                        !string.IsNullOrEmpty(x.Employee.LastName)
                            ? $"{x.Employee.FirstName} {x.Employee.LastName}"
                            : x.Employee.UserName))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(x => $"{x.EmployeeId.ToString()}"))
                .ForMember(x => x.CarHelpId, y => y.MapFrom(x => x.Id.ToString()));

            CreateMap<CreateCarHelpRequestViewModel, CreateCarHelpEntryRequestDto>().ReverseMap();
            CreateMap<UpdateCarHelpRequestViewModel, UpdateCarHelpEntryRequestDto>().ReverseMap();
            CreateMap<DeleteCarHelpRequestViewModel, DeleteCarHelpRequestDto>().ReverseMap();
        }
    }
}
