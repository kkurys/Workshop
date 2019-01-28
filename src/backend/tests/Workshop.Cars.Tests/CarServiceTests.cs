using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Cars.Contracts;
using Workshop.Cars.Dto;
using Workshop.Cars.Services;
using Workshop.Data.Contracts;
using Workshop.Data.Models.Car;
using Workshop.TestUtils;

namespace Workshop.Cars.Tests
{

    [TestFixture]
    public class CarServiceTests
    {
        private readonly Mock<IDataService> _fakeDb;
        private ICarService _sut;
        public CarServiceTests()
        {
            _fakeDb = new Mock<IDataService>();
        }

        [Test]
        public async Task CreateCar_Invoke()
        {
            var dto = new CreateCarRequestDto
            {
                Description = "test",
                Model = "test",
                User = null
            };

            var cars = new List<Car>().AsQueryable();

            var mockCarSet = FakeDbSetFactory<Car>.Get(cars);

            _fakeDb.Setup(m => m.GetSet<Car>()).Returns(mockCarSet.Object);

            _sut = new CarService(_fakeDb.Object);

            await _sut.CreateCar(dto);

            _fakeDb.Verify(v => v.GetSet<Car>());
            _fakeDb.Verify(v => v.SaveDbAsync());
        }

        [Test]
        public async Task UpdateCar_Invoke()
        {
            var car = new Car
            {
                Id = Guid.NewGuid(),
                Description = "test",
                Model = "test",
            };

            var dto = new UpdateCarRequestDto
            {
                Id = car.Id.ToString(),
                Description = "edited_desc",
                Model = "edited",
            };

            var cars = new List<Car> {car}.AsQueryable();

            var mockCarSet = FakeDbSetFactory<Car>.Get(cars);

            _fakeDb.Setup(m => m.GetSet<Car>()).Returns(mockCarSet.Object);
            _sut = new CarService(_fakeDb.Object);

            await _sut.UpdateCar(dto);

            _fakeDb.Verify(v => v.GetSet<Car>());
            _fakeDb.Verify(v => v.SaveDbAsync());

            car.Model.Should().Be(dto.Model);
            car.Description.Should().Be(dto.Description);
        }

        [Test]
        public async Task GetCars_Invoke()
        {
            var car = new Car
            {
                Id = Guid.NewGuid(),
                Description = "test",
                Model = "test",
            };
            var car2 = new Car
            {
                Id = Guid.NewGuid(),
                Description = "test2",
                Model = "tes2t",
            };

            var cars = new List<Car> { car, car2 }.AsQueryable();

            var mockCarSet = FakeDbSetFactory<Car>.Get(cars);

            _fakeDb.Setup(m => m.GetSet<Car>()).Returns(mockCarSet.Object);
            _sut = new CarService(_fakeDb.Object);

            var result = await _sut.GetCars();

            result.TotalCount.Should().Be(2);
        }
    }
}
