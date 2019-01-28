using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Account.Contracts;
using Workshop.Api.ViewModels.Car;
using Workshop.Cars.Contracts;
using Workshop.Cars.Dto;

namespace Workshop.Api.Controllers
{
    /// <summary>
    /// Car api methods
    /// </summary>
    [Authorize]
    public class CarController: WorkshopBaseController
    {
        private readonly ICarService _carService;
        private readonly IUserService _userService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="carService"></param>
        /// <param name="userService"></param>
        public CarController(ICarService carService, IUserService userService)
        {
            _carService = carService;
            _userService = userService;
        }

        /// <summary>
        /// Endpoint for creating cars
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles="Client")]
        public async Task CreateCar([FromBody] CreateCarRequestViewModel request)
        {
            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);

            var model = Mapper.Map<CreateCarRequestDto>(request);

            model.User = currentUser;

            await _carService.CreateCar(model);
        }

        /// <summary>
        /// Endpoint for updating car
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Client")]
        public async Task UpdateCar([FromBody] UpdateCarRequestViewModel request)
        {
            var model = Mapper.Map<UpdateCarRequestDto>(request);

            await _carService.UpdateCar(model);
        }

        /// <summary>
        /// Endpoint for deleting car
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task DeleteCar([FromBody] DeleteCarRequestViewModel request)
        {
            var model = Mapper.Map<DeleteCarRequestDto>(request);

            await _carService.DeleteCar(model);
        }

        /// <summary>
        /// Endpoint for car listing
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetCars(int skip = 0, int take = 10)
        {
            var result = await _carService.GetCars(skip, take);

            return Json(result);
        }

        public async Task<JsonResult> GetUserCars(int skip = 0, int take = 10)
        {
            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);

            var result = await _carService.GetCars(skip, take, currentUser);

            return Json(result);
        }

        public async Task<JsonResult> GetCarById(string id)
        {
            var result = await _carService.GetCarById(id);

            var response = new CarResponseViewModel
            {
                Car = result
            };

            return Json(response);
        }
    }
}
