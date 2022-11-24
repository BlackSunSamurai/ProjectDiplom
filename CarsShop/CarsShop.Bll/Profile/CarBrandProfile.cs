using CarsShop.Common.DTO.BrandCars;
using CarsShop.Domain;

namespace CarsShop.Bll.Profile;

public class CarBrandProfile : AutoMapper.Profile
{
    public CarBrandProfile()
    {
        CreateMap<CarBrand,CreateBrand>();
        CreateMap<CarBrand,GetCarsBrandDto>();
        
        CreateMap<CreateBrand,CarBrand>();
        CreateMap<GetCarsBrandDto,CreateBrand>();
    }
}