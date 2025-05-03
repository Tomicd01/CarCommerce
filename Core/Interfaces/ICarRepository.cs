using CarShopApi.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopApi.Core.Interfaces
{
    public interface ICarRepository
    {
        Task<Car> GetCarByIdAsync(int id);
        Task<IReadOnlyList<Car>> GetCarsAsync();
        Task<IReadOnlyList<CarManufacturer>> GetCarManufacturersAsync();
        Task<IReadOnlyList<CarType>> GetCarTypesAsync();
    }
}
