using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Workshop.Account.Contracts;
using Workshop.Account.Dto;
using Workshop.Data.Contracts;
using Workshop.Data.Models.Account;

namespace Workshop.Account.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<WorkshopUser> _userManager;

        public UserService(UserManager<WorkshopUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var users = await _userManager
                .Users
                .Select(x => Mapper.Map<UserDto>(x))
                .ToListAsync();

            return users;
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var result = Mapper.Map<WorkshopUser, UserDto>(user);

            var roleName = (await _userManager.GetRolesAsync(user)).First();

            return result;
        }

        public async Task<WorkshopUser> GetUserByName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }
    }
}
