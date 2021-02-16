using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class CarController
    {
        public ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;

        }
        public async Task<List<Car>> GetListOfCars()
        {
            var result = await _carRepository.GetCarsAsync();
            return result;
        }
        public async Task<Car> AddCar(Car car)
        {
            var result = await _carRepository.AddCarAsync(car);
            return result;
        }
        public async Task<Car> DeleteCar(Car car)
        {
            var result = await _carRepository.DeleteCarAsync(car);
            return result;
        }
        public async Task<Car> UpdateCar(Car car)
        {
            var result = await _carRepository.UpdateCarAsync(car);
            return result;
        }
    }
}