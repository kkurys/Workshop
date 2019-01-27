using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Workshop.Account.Contracts;
using Workshop.Account.Dto;
using Workshop.ViewModels.Account;

namespace Workshop.Controllers
{
    /// <summary>
    /// Api endpoint for sign in and registration
    /// </summary>
    public class AuthController : WorkshopBaseController
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Auth controller ctor
        /// </summary>
        /// <param name="authService"></param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Api method for register
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Register([FromBody] RegisterRequestViewModel model)
        {
            var dto = Mapper.Map<RegisterRequestDto>(model);

            var token = await _authService.Register(dto);

            return Json(token);
        }

        /// <summary>
        /// Api method for sign in
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Login([FromBody] SignInRequestViewModel model)
        {
            var dto = Mapper.Map<SignInRequestDto>(model);

            var token = await _authService.SignIn(dto);

            return Json(token);
        }
    }
}
