using AutoMapper;
using Workshop.Account.Dto;
using Workshop.Api.ViewModels.Account;
using Workshop.Data.Models.Account;

namespace Workshop.Api.MappingProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterRequestDto, RegisterRequestViewModel>().ReverseMap();
            CreateMap<SignInRequestDto, SignInRequestViewModel>().ReverseMap();
            CreateMap<WorkshopUser, UserDto>().ReverseMap();
        }
    }
}