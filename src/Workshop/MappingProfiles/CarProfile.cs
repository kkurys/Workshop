using AutoMapper;
using Workshop.Cars.Dto;
using Workshop.Data.Models.Car;
using Workshop.ViewModels.Car;

namespace Workshop.MappingProfiles
{
    public class CarProfile: Profile
    {
        public CarProfile()
        {
            CreateMap<CreateCarRequestViewModel, CreateCarRequestDto>().ReverseMap();
            CreateMap<UpdateCarRequestViewModel, UpdateCarRequestDto>().ReverseMap();
            CreateMap<DeleteCarRequestViewModel, DeleteCarRequestDto>().ReverseMap();
            CreateMap<CarDto, Car>().ReverseMap();
        }
    }
}
