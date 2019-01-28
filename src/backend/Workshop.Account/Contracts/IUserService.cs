using System.Collections.Generic;
using System.Threading.Tasks;
using Workshop.Account.Dto;
using Workshop.Data.Models.Account;

namespace Workshop.Account.Contracts
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserAsync(string id);
        Task<WorkshopUser> GetUserByName(string userName);
    }
}
