using CarsShop.Common.DTO.Car;
using CarsShop.Domain;

namespace CarsShop.Bll.Profile;

public class CarProfile : AutoMapper.Profile
{
    public CarProfile()
    {
        CreateMap<Car, CreateCar>();
        CreateMap<Car, GetCarsDto>();
        
        CreateMap<CreateCar,Car>();
        CreateMap<GetCarsDto,Car>();

        CreateMap<Car, GetCarsDto>()
            .ForMember(x => x.CarBrand,
                o => o.MapFrom(s => s.CarBrand.Name))
            .ForMember(x => x.CarType, o =>
                o.MapFrom(s => s.CarType.Name));
    }
}