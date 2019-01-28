using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workshop.Account.Contracts;
using Workshop.Api.ViewModels.Account;

namespace Workshop.Api.Controllers
{
    /// <summary>
    /// User endpoint
    /// </summary>
    public class UserController: WorkshopBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Endpoint for fetching users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetUsers()
        {
            var result = await _userService.GetUsersAsync();

            var response = new UsersResponseViewModel
            {
                Users = result
            };
            
            return Json(response);
        }
    }
}
