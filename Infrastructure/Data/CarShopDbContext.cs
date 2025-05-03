using CarShopApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CarShopDbContext : DbContext
    {
        public CarShopDbContext(DbContextOptions<CarShopDbContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
              .Property(c => c.Id).IsRequired();
            modelBuilder.Entity<Car>()
               .Property(c => c.Model).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Car>()
               .Property(c => c.Description).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Car>()
                .Property(c => c.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Car>()
                .Property(c => c.PictureUrl).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Manufacturer)
                .WithMany()
                .HasForeignKey(c => c.ManufacturerId);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Type)
                .WithMany()
                .HasForeignKey(c => c.TypeId);

        }
    }
}
