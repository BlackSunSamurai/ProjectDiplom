using CarsShop.Common.DTO.BrandCars;
using CarsShop.Common.DTO.Car;
using CarsShop.Common.DTO.TypeCars;

namespace CarsShop.Bll.Interfaces;

public interface ICarService
{
    public Task<GetCarsDto> DeleteCars(int id);
    public Task<GetCarsBrandDto> DeleteBrand(int id);
    public Task<GetTypeCars> DeleteType(int id);
    public Task<IEnumerable<GetCarsDto>> GetCars();
    public Task<IEnumerable<GetCarsBrandDto>> GetCarsBrands();
    public Task<IEnumerable<GetTypeCars>> GetCarsType();

    public Task<GetCarsDto> CreateCar(CreateCar car);
    public Task<GetCarsBrandDto> CreateBrand(CreateBrand brand);
    public Task<GetTypeCars> CreateType(CreateType type);
}