using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Workshop.Account.Contracts;
using Workshop.Api.ViewModels.CarHelpEntry;
using Workshop.CarHelp.Contracts;
using Workshop.CarHelp.Dto;

namespace Workshop.Api.Controllers
{
    /// <summary>
    /// Car service endpoint
    /// </summary>
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

        /// <summary>
        /// Api for creating car help entries
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]   
        [Authorize(Roles="Manager")]
        public async Task CreateCarHelpEntry([FromBody]CreateCarHelpRequestViewModel request)
        {
            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);
            var model = Mapper.Map<CreateCarHelpEntryRequestDto>(request);
            model.Employee = currentUser;

            await _carHelpEntryService.CreateCarHelpEntry(model);
        }

        /// <summary>
        /// Endpoint for updating car help entries
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Manager")]
        public async Task UpdateCarHelpEntry([FromBody]UpdateCarHelpRequestViewModel request)
        {
            var model = Mapper.Map<UpdateCarHelpEntryRequestDto>(request);

            await _carHelpEntryService.UpdateCarHelpEntry(model);
        }

        /// <summary>
        /// Endpoint for deleting car help entries
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task DeleteCarHelpEntry([FromBody] DeleteCarHelpRequestViewModel request)
        {
            var model = Mapper.Map<DeleteCarHelpRequestDto>(request);

            await _carHelpEntryService.DeleteCarHelpEntry(model);
        }

        /// <summary>
        /// Endpoint for fetching car help entries. Optionally for car.
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetCarHelpEntries(string carId = "", int skip = 0, int take = 10)
        {
            var result = await _carHelpEntryService.GetCarHelpEntries(carId, skip, take);

            return Json(result);
        }

        /// <summary>
        /// Endpoint for getting details about a car help entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
