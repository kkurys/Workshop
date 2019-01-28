using System.Threading.Tasks;
using Workshop.CarHelp.Dto;

namespace Workshop.CarHelp.Contracts
{
    public interface ICarHelpEntryService
    {
        Task CreateCarHelpEntry(CreateCarHelpEntryRequestDto request);
        Task UpdateCarHelpEntry(UpdateCarHelpEntryRequestDto request);
        Task<CarHelpEntryListingDto> GetCarHelpEntries(string carId = "", int skip = 0, int take = 10);
        Task<CarHelpEntryDto> GetCarHelpEntryById(string id);
        Task DeleteCarHelpEntry(DeleteCarHelpRequestDto model);
    }
}