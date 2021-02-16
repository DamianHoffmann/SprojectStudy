using Application;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sproject
{
    [Route("v1/cars")]
    [ApiController]
    public class CarApiController : ControllerBase
    {
        private readonly CarController _carController;

        public CarApiController(CarController carController)
        {
            _carController = carController;
        }


        [HttpGet("getCars")]
        public async Task<List<Car>> GetCars()
        {

          var result =  await _carController.GetListOfCars();

            return result;

        }

        [HttpPost("createCar")]
        public async Task<OkResult> CreateCar(Car car)
        {

            await _carController.AddCar(car);

            return Ok();

        }
        [HttpPost("updateCar")]
        public async Task<OkResult> UpdateCar(Car car)
        {

            await _carController.UpdateCar(car);

            return Ok();

        }
        [HttpPost("deleteCar")]
        public async Task<OkResult> DeleteCar(Car car)
        {

            await _carController.DeleteCar(car);

            return Ok();

        }
    }
}
