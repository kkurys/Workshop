using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Workshop.CarHelp.Contracts;
using Workshop.CarHelp.Dto;
using Workshop.Common.Exceptions;
using Workshop.Data.Contracts;
using Workshop.Data.Models.CarHelp;

namespace Workshop.CarHelp.Services
{
    public class CarHelpEntryService : ICarHelpService
    {
        private readonly IDataService _dataService;

        public CarHelpEntryService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task CreateCarHelpEntry(CreateCarHelpEntryRequestDto request)
        {
            var model = new CarHelpEntry
            {
                Name = request.Name,
                CarId = new Guid(request.CarId),
                Employee = request.Employee,
                Created = DateTime.UtcNow,
                Description = request.Description,
                Price = request.Price,
                Status = request.Status
            };

            await _dataService.GetSet<CarHelpEntry>().AddAsync(model);
            await _dataService.SaveDbAsync();
        }

        public async Task<CarHelpEntryListingDto> GetCarHelpEntries(string carId = "", int skip = 0, int take = 10)
        {
            var resultQuery = _dataService.GetSet<CarHelpEntry>()
                                 .Where(x => string.IsNullOrEmpty(carId) || x.CarId.ToString() == carId);

            var result = new CarHelpEntryListingDto
            {
                TotalCount = resultQuery.Count(),
                CarHelpEntries = await resultQuery
                    .OrderByDescending(x => x.Updated ?? x.Created)
                    .Skip(skip * take)
                    .Take(take)
                    .Select(x => Mapper.Map<CarHelpEntryDto>(x))
                    .ToListAsync()
            };

            return result;
        }

        public async Task<CarHelpEntryDto> GetCarHelpEntryById(string id)
        {
            var model = await _dataService.GetSet<CarHelpEntry>().FirstOrDefaultAsync(x => x.Id.ToString() == id);

            if (model == null)
            {
                throw new InvalidCarHelpEntryIdException();
            }

            var result = Mapper.Map<CarHelpEntryDto>(model);

            return result;
        }

        public async Task UpdateCarHelpEntry(UpdateCarHelpEntryRequestDto request)
        {
            var carHelpEntrySet = _dataService.GetSet<CarHelpEntry>();

            var carHelpEntry = await carHelpEntrySet.FirstOrDefaultAsync(x => x.Id.ToString() == request.CarHelpId);

            if (carHelpEntry == null)
            {
                throw new InvalidCarHelpEntryIdException();
            }

            carHelpEntry.Description = request.Description;
            carHelpEntry.Price = request.Price;
            carHelpEntry.Name = request.Name;
            carHelpEntry.Status = request.Status;
            carHelpEntry.Updated = DateTime.UtcNow;

            await _dataService.SaveDbAsync();
        }
    }
}
