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
        private readonly ICarHelpEntryService _carHelpEntryService;
        private readonly IUserService _userService;

        public CarHelpEntryController(ICarHelpEntryService carHelpEntryService, IUserService userService)
        {
            _carHelpEntryService = carHelpEntryService;
            _userService = userService;
        }

        [HttpPost]   
        [Authorize(Roles="Manager")]
        public async Task CreateCarHelpEntry([FromBody]CreateCarHelpRequestViewModel request)
        {
            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);
            var model = Mapper.Map<CreateCarHelpEntryRequestDto>(request);
            model.Employee = currentUser;

            await _carHelpEntryService.CreateCarHelpEntry(model);
        }

        [HttpPut]
        [Authorize(Roles = "Manager")]
        public async Task UpdateCarHelpEntry([FromBody]UpdateCarHelpRequestViewModel request)
        {
            var model = Mapper.Map<UpdateCarHelpEntryRequestDto>(request);

            await _carHelpEntryService.UpdateCarHelpEntry(model);
        }

        public async Task<JsonResult> GetCarHelpEntries(string carId = "", int skip = 0, int take = 10)
        {
            var result = await _carHelpEntryService.GetCarHelpEntries(carId, skip, take);

            return Json(result);
        }

        public async Task<JsonResult> GetCarHelpEntryById(string id)
        {
            var result = await _carHelpEntryService.GetCarHelpEntryById(id);

            var response = new CarHelpEntryResponseViewModel
            {
                CarHelpEntry = result
            };

            return Json(response);
        }
    }
}
