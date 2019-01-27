using AutoMapper;
using Workshop.Account.Dto;
using Workshop.ViewModels.Account;

namespace Workshop.MappingProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterRequestDto, RegisterRequestViewModel>().ReverseMap();
            CreateMap<SignInRequestDto, SignInRequestViewModel>().ReverseMap();
        }
    }
}
