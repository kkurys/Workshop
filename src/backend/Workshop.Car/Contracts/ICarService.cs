using System.Threading.Tasks;
using Workshop.Cars.Dto;
using Workshop.Data.Models.Account;

namespace Workshop.Cars.Contracts
{
    public interface ICarService
    {
        Task CreateCar(CreateCarRequestDto request);
        Task UpdateCar(UpdateCarRequestDto request);
        Task DeleteCar(DeleteCarRequestDto request);
        Task<CarListingDto> GetCars(int skip = 0, int take = 10, WorkshopUser user = null);
        Task<CarDto> GetCarById(string id);

    }
}
