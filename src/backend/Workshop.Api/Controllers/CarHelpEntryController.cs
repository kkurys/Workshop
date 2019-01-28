using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workshop.Account.Contracts;
using Workshop.Api.ViewModels.CarHelpEntry;
using Workshop.CarHelp.Contracts;
using Workshop.CarHelp.Dto;

namespace Workshop.Api.Controllers
{
    [Authorize]
    public class CarHelpEntryController: WorkshopBaseController
    {
        private readonly ICarHelpService _carHelpService;
        private readonly IUserService _userService;

        public CarHelpEntryController(ICarHelpService carHelpService, IUserService userService)
        {
            _carHelpService = carHelpService;
            _userService = userService;
        }

        [HttpPost]   
        [Authorize(Roles="Manager")]
        public async Task CreateCarHelpEntry([FromBody]CreateCarHelpRequestViewModel request)
        {
            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);
            var model = Mapper.Map<CreateCarHelpEntryRequestDto>(request);
            model.Employee = currentUser;

            await _carHelpService.CreateCarHelpEntry(model);
        }

        [HttpPut]
        [Authorize(Roles = "Manager")]
        public async Task UpdateCarHelpEntry([FromBody]UpdateCarHelpRequestViewModel request)
        {
            var model = Mapper.Map<UpdateCarHelpEntryRequestDto>(request);

            await _carHelpService.UpdateCarHelpEntry(model);
        }

        public async Task<JsonResult> GetCarHelpEntries(string carId = "", int skip = 0, int take = 10)
        {
            var result = await _carHelpService.GetCarHelpEntries(carId, skip, take);

            return Json(result);
        }

        public async Task<JsonResult> GetCarHelpEntryById(string id)
        {
            var result = await _carHelpService.GetCarHelpEntryById(id);

            var response = new CarHelpEntryResponseViewModel
            {
                CarHelpEntry = result
            };

            return Json(response);
        }
    }
}
