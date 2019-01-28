using System.Net.Mail;
using Workshop.Account.Contracts;
using Workshop.Account.Dto;
using Workshop.Common.Exceptions;

namespace Workshop.Account.Services
{
    public class AuthValidationService : IAuthValidationService
    {
        public void ValidateRegisterViewModel(RegisterRequestDto model)
        {
            try
            {
                var mailAddress = new MailAddress(model.Email);
            }
            catch
            {
                throw new RegisterFailedException(
                    "Invalid email!");
            }

            if (string.IsNullOrEmpty(model.Password))
                throw new RegisterFailedException(
                    "Password cannot be null!");

            if (string.IsNullOrEmpty(model.UserName))
                throw new RegisterFailedException(
                    "Registration error: UserName cannot be null!");
        }

        public void ValidateSignInViewModel(SignInRequestDto model)
        {
            if (string.IsNullOrEmpty(model.Password))
                throw new SignInFailedException(
                    "Password cannot be empty nor null!");

            if (string.IsNullOrEmpty(model.UserName))
                throw new SignInFailedException(
                    "UserName cannot be empty nor null!");
        }
    }
}