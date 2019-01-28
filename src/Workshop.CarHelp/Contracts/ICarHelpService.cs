using System.Threading.Tasks;
using Workshop.CarHelp.Dto;

namespace Workshop.CarHelp.Contracts
{
    public interface ICarHelpService
    {
        Task CreateCarHelpEntry(CreateCarHelpEntryRequestDto Request);
        Task UpdateCarHelpEntry(UpdateCarHelpEntryRequestDto request);
        Task<CarHelpEntryListingDto> GetCarHelpEntries(string carId = "", int skip = 0, int take = 10);
        Task<CarHelpEntryDto> GetCarHelpEntryById(string id);
    }
}
