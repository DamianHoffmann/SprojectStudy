using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsAsync();
        Task<Car> AddCarAsync(Car car);
        Task<Car> DeleteCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
    }
}
