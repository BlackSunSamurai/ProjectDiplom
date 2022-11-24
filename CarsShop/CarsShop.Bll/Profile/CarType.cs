using CarsShop.Common.DTO.TypeCars;

namespace CarsShop.Bll.Profile;

public class CarType : AutoMapper.Profile
{
    public CarType()
    {
        CreateMap<Domain.CarType,CreateType>();
        CreateMap<Domain.CarType,GetTypeCars>();
        
        CreateMap<CreateType,Domain.CarType>();
        CreateMap<GetTypeCars,Domain.CarType>();
    }
}