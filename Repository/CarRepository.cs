using Domain;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CarRepository : EfRepository, ICarRepository
    {
        public CarRepository(IApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<List<Car>> GetCarsAsync()
        {
            var result = await Context.Cars.ToListAsync();

             
            return result;
        }
        public async Task<Car> AddCarAsync(Car car)
        {
              await Context.Cars.AddAsync(car);


            return car;
        }
        public async Task<Car> UpdateCarAsync(Car car)
        {
            var databaseCar = await Context.Cars.SingleAsync(x => x.Id == car.Id);
            databaseCar.Name = car.Name;
            databaseCar.Color = car.Color;
            databaseCar.Price = car.Price;
            databaseCar.Doors = car.Doors;
            await Context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> DeleteCarAsync(Car car)
        {
            var databaseCar = await Context.Cars.SingleAsync(x => x.Id == car.Id);
            databaseCar.Name = car.Name;
            databaseCar.Color = car.Color;
            databaseCar.Price = car.Price;
            databaseCar.Doors = car.Doors;

            Context.Cars.Remove(databaseCar);
    
           await  Context.SaveChangesAsync();

            return car;
        }
    }
}
