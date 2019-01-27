using Workshop.Account.Dto;

namespace Workshop.Account.Contracts
{
    public interface IAuthValidationService
    {
        void ValidateRegisterViewModel(RegisterRequestDto model);
        void ValidateSignInViewModel(SignInRequestDto model);
    }
}
