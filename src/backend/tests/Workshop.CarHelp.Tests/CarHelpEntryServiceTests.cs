using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Workshop.CarHelp.Contracts;
using Workshop.CarHelp.Dto;
using Workshop.CarHelp.Services;
using Workshop.Data.Contracts;
using Workshop.Data.Models.CarHelp;
using Workshop.TestUtils;

namespace Workshop.CarHelp.Tests
{
    [TestFixture]
    public class CarHelpEntryServiceTests
    {
        private readonly Mock<IDataService> _fakeDb;
        private ICarHelpEntryService _sut;

        public CarHelpEntryServiceTests()
        {
            _fakeDb = new Mock<IDataService>();
        }

        [Test]
        public async Task CreateCarHelpEntry_Invoke()
        {
            var dto = new CreateCarHelpEntryRequestDto
            {
                Description = "test",
                CarId = Guid.NewGuid().ToString()
            };

            var cars = new List<CarHelpEntry>().AsQueryable();

            var mockCarHelpEntrySet = FakeDbSetFactory<CarHelpEntry>.Get(cars);

            _fakeDb.Setup(m => m.GetSet<CarHelpEntry>()).Returns(mockCarHelpEntrySet.Object);

            _sut = new CarHelpEntryService(_fakeDb.Object);

            await _sut.CreateCarHelpEntry(dto);

            _fakeDb.Verify(v => v.GetSet<CarHelpEntry>());
            _fakeDb.Verify(v => v.SaveDbAsync());
        }

        [Test]
        public async Task GetCarHelpEntries_Invoke()
        {
            var carHelpEntry = new CarHelpEntry
            {
                Id = Guid.NewGuid()
            };

            var carHelpEntry2 = new CarHelpEntry
            {
                Id = Guid.NewGuid()
            };

            var carHelpEntries = new List<CarHelpEntry> {carHelpEntry, carHelpEntry2}.AsQueryable();

            var mockCarSet = FakeDbSetFactory<CarHelpEntry>.Get(carHelpEntries);

            _fakeDb.Setup(m => m.GetSet<CarHelpEntry>()).Returns(mockCarSet.Object);
            _sut = new CarHelpEntryService(_fakeDb.Object);

            var result = await _sut.GetCarHelpEntries();

            result.TotalCount.Should().Be(2);
        }

        [Test]
        public async Task UpdateCarHelpEntry_Invoke()
        {
            var carHelpEntry = new CarHelpEntry
            {
                Id = Guid.NewGuid()
            };

            var dto = new UpdateCarHelpEntryRequestDto
            {
                CarHelpId = carHelpEntry.Id.ToString(),
                Description = "test"
            };


            var carHelpEntries = new List<CarHelpEntry> {carHelpEntry}.AsQueryable();

            var mockCarSet = FakeDbSetFactory<CarHelpEntry>.Get(carHelpEntries);

            _fakeDb.Setup(m => m.GetSet<CarHelpEntry>()).Returns(mockCarSet.Object);
            _sut = new CarHelpEntryService(_fakeDb.Object);

            await _sut.UpdateCarHelpEntry(dto);

            _fakeDb.Verify(v => v.GetSet<CarHelpEntry>());
            _fakeDb.Verify(v => v.SaveDbAsync());

            carHelpEntry.Description.Should().Be(dto.Description);
        }
    }
}