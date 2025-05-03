using Core.Entities;

namespace CarShopApi.Core.Entities
{
    public class Car : BaseEntity
    {
        public CarManufacturer Manufacturer { get; set; } //BMW
        public int ManufacturerId { get; set; } //BMW
        public string Model { get; set; } //X6
        public string Description { get; set; } // SuV car 
        public decimal Price { get; set; } // 150000
        public string PictureUrl { get; set; } // https://example.com/image.jpg`
        public CarType Type { get; set; } // SUV
        public int TypeId { get; set; } // 1
    }
}
