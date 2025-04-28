using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CarShopApi.Core.Entities;
using CarShopApi.Core.Interfaces;
using CarShopApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CarRepository : ICarRepository
    {
        private readonly CarShopDbContext _context;
        public CarRepository(CarShopDbContext context)
        {
            _context = context;
        }
        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<IReadOnlyList<Car>> GetCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }
    }
}
