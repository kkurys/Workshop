using System.Threading.Tasks;
using Workshop.Account.Dto;

namespace Workshop.Account.Contracts
{
    public interface IAuthService
    {
        Task<string> Register(RegisterRequestDto model);
        Task<string> SignIn(SignInRequestDto model);
    }
}