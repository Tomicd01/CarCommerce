using CarShopApi.Core.Entities;

namespace CarShopApi.Dtos
{
    public class CarToReturnDto
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; } //BMW
        public string Model { get; set; } //X6
        public string Description { get; set; } // SuV car 
        public decimal Price { get; set; } // 150000
        public string PictureUrl { get; set; } // https://example.com/image.jpg`
        public string Type { get; set; } // SUV
    }
}
