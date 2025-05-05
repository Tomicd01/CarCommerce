using AutoMapper;
using CarShopApi.Core.Entities;
using CarShopApi.Dtos;
using System.Net.Http.Headers;

namespace CarShopApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Car, CarToReturnDto>()
                .ForMember(cartoreturn => cartoreturn.Manufacturer, o => o.MapFrom(car => car.Manufacturer.Name))
                .ForMember(cartoreturn => cartoreturn.Type, o => o.MapFrom(car => car.Type.Name))
                .ForMember(cartoreturn => cartoreturn.PictureUrl, o => o.MapFrom<CarUrlResolver>());           
        }
    }
}
