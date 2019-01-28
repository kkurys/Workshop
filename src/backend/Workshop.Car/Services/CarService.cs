using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Workshop.Cars.Contracts;
using Workshop.Cars.Dto;
using Workshop.Common.Exceptions;
using Workshop.Data.Contracts;
using Workshop.Data.Models.Car;

namespace Workshop.Cars.Services
{
    public class CarService: ICarService
    {
        private readonly IDataService _dataService;

        public CarService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task CreateCar(CreateCarRequestDto request)
        {
            var car = new Car
            {
                Year = request.Year,
                Description = request.Description,
                Model = request.Model,
                CreatedOn = DateTime.UtcNow
            };

            await _dataService.GetSet<Car>().AddAsync(car);
            await _dataService.SaveDbAsync();
        }

        public async Task UpdateCar(UpdateCarRequestDto request)
        {
            var carSet = _dataService.GetSet<Car>();

            var car = await carSet.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);

            if (car == null)
            {
                throw new InvalidCarIdException($"Cannot find car for id: {request.Id}");
            }

            car.Description = request.Description;
            car.Model = request.Model;
            car.Year = request.Year;

            carSet.Update(car);

            await _dataService.SaveDbAsync();
        }

        public async Task DeleteCar(DeleteCarRequestDto request)
        {
            var carSet = _dataService.GetSet<Car>();

            var car = await carSet.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);

            if (car == null)
            {
                throw new InvalidCarIdException($"Cannot find car for id: {request.Id}");
            }

            carSet.Remove(car);

            await _dataService.SaveDbAsync();
        }

        public async Task<CarListingDto> GetCars(int skip = 0, int take = 10)
        {
            var cars =
                _dataService.GetSet<Car>()
                    .OrderByDescending(x => x.CreatedOn);

            var result = new CarListingDto
            {
                TotalCount = cars.Count(),
                Cars = await cars.
                    Skip(skip * take)
                    .Take(take)
                    .Select(x => Mapper.Map<CarDto>(x))
                    .ToListAsync()
            };

            return result;
        }

        public async Task<CarDto> GetCarById(string id)
        {
            var car = await _dataService.GetSet<Car>().FirstOrDefaultAsync(x => x.Id.ToString() == id);

            var result = Mapper.Map<CarDto>(car);

            return result;
        }
    }
}
