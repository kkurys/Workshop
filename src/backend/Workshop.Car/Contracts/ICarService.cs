using System.Threading.Tasks;
using Workshop.Cars.Dto;

namespace Workshop.Cars.Contracts
{
    public interface ICarService
    {
        Task CreateCar(CreateCarRequestDto request);
        Task UpdateCar(UpdateCarRequestDto request);
        Task DeleteCar(DeleteCarRequestDto request);
        Task<CarListingDto> GetCars(int skip = 0, int take = 10);
    }
}
