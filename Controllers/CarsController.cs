using CarShopApi.Core.Entities;
using CarShopApi.Core.Interfaces;
using Core.Interfaces;
using Core.Specifications;
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
        private readonly IGenericRepository<Car> _carRepo;
        private readonly IGenericRepository<CarManufacturer> _manuRepo;
        private readonly IGenericRepository<CarType> _typeRepo;
        public CarsController(IGenericRepository<Car> carRepo, 
            IGenericRepository<CarManufacturer> manuRepo, 
            IGenericRepository<CarType> typeRepo)
        {
            _carRepo = carRepo;
            _manuRepo = manuRepo;
            _typeRepo = typeRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars()
        {
            var spec = new CarsWithTypesAndBrandsSpecification();

            var cars = await _carRepo.ListAsync(spec);
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<Car> GetCar(int id)
        {
            var spec = new CarsWithTypesAndBrandsSpecification(id);

            return await _carRepo.GetEntityWithSpec(spec);
        }

        [HttpGet("manufacturers")]
        public async Task<ActionResult<IReadOnlyList<CarManufacturer>>> GetCarManufacturers()
        {
            return Ok(await _manuRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<CarManufacturer>>> GetCarTypes()
        {
            return Ok(await _typeRepo.ListAllAsync());
        }
    }
}
