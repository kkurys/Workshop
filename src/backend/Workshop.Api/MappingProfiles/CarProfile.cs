using AutoMapper;
using Workshop.Api.ViewModels.Car;
using Workshop.Cars.Dto;
using Workshop.Data.Models.Car;

namespace Workshop.Api.MappingProfiles
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
