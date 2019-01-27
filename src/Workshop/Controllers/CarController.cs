using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Workshop.Cars.Contracts;
using Workshop.Cars.Dto;
using Workshop.ViewModels.Car;

namespace Workshop.Controllers
{
    /// <summary>
    /// Car api methods
    /// </summary>
    public class CarController: WorkshopBaseController
    {
        private readonly ICarService _carService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="carService"></param>
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>
        /// Endpoint for creating cars
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateCar([FromBody] CreateCarRequestViewModel request)
        {
            var model = Mapper.Map<CreateCarRequestDto>(request);

            await _carService.CreateCar(model);
        }

        /// <summary>
        /// Endpoint for updating car
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
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
    }
}
