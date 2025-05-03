using CarShopApi.Core.Entities;
using CarShopApi.Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {  
        private readonly ICarRepository _carRepository;
        public CarsController(ICarRepository repo)
        {
            _carRepository = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars()
        {
            var cars = await _carRepository.GetCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<Car> GetCar(int id)
        {
            return await _carRepository.GetCarByIdAsync(id);
        }

        [HttpGet("manufacturers")]
        public async Task<ActionResult<IReadOnlyList<CarManufacturer>>> GetCarManufacturers()
        {
            return Ok(await _carRepository.GetCarManufacturersAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<CarManufacturer>>> GetCarTypes()
        {
            return Ok(await _carRepository.GetCarTypesAsync());
        }
    }
}
