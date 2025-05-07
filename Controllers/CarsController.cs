using AutoMapper;
using CarShopApi.Core.Entities;
using CarShopApi.Core.Interfaces;
using CarShopApi.Dtos;
using CarShopApi.Errors;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShopApi.Controllers
{
    public class CarsController : BaseApiController
    {  
        private readonly IGenericRepository<Car> _carRepo;
        private readonly IGenericRepository<CarManufacturer> _manuRepo;
        private readonly IGenericRepository<CarType> _typeRepo;
        private readonly IMapper _mapper;

        public CarsController(IGenericRepository<Car> carRepo, 
            IGenericRepository<CarManufacturer> manuRepo, 
            IGenericRepository<CarType> typeRepo,
            IMapper mapper)
        {
            _carRepo = carRepo;
            _manuRepo = manuRepo;
            _typeRepo = typeRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CarToReturnDto>>> GetCars()
        {
            var spec = new CarsWithTypesAndBrandsSpecification();

            var cars = await _carRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Car>, IReadOnlyList<CarToReturnDto>>(cars));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // ovim kazemo swaggeru da response moze da bude 200 i 404
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CarToReturnDto>> GetCar(int id)
        {
            var spec = new CarsWithTypesAndBrandsSpecification(id);

            var car = await _carRepo.GetEntityWithSpec(spec);

            if(car == null)
            {
                return NotFound(new ApiResponse(400));
            }

            return _mapper.Map<Car, CarToReturnDto>(car);
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
