using AutoMapper;
using CarsShop.Bll.Interfaces;
using CarsShop.Common.DTO.BrandCars;
using CarsShop.Common.DTO.Car;
using CarsShop.Common.DTO.TypeCars;
using CarsShop.Dal.Interfaces;
using CarsShop.Domain;

namespace CarsShop.Bll.Services;

public class CarService : ICarService
{
    private readonly IRepository<Car> _carRepository; 
    private readonly IRepository<CarBrand> _brandRepository;
    private readonly IRepository<CarType> _typeRepository;
    private readonly IMapper _mapper;

    public CarService(IRepository<Car> carRepository, IRepository<CarBrand> brandRepository, IRepository<CarType> typeRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _brandRepository = brandRepository;
        _typeRepository = typeRepository;
        _mapper = mapper;
    }

    #region Create

    public async Task<GetCarsDto> CreateCar(CreateCar car)
    {
        var cars = _mapper.Map<Car>(car);
        await _carRepository.AddAsync(cars);
        await _carRepository.SaveChangesAsync();
        return _mapper.Map<GetCarsDto>(cars);
    }

    public async Task<GetCarsBrandDto> CreateBrand(CreateBrand brand)
    {
        var brands = _mapper.Map<CarBrand>(brand);
        await _brandRepository.AddAsync(brands);
        await _brandRepository.SaveChangesAsync();
        return _mapper.Map<GetCarsBrandDto>(brands);
    }

    public async Task<GetTypeCars> CreateType(CreateType type)
    {
        var types = _mapper.Map<CarType>(type);
        await _typeRepository.AddAsync(types);
        await _typeRepository.SaveChangesAsync();
        return _mapper.Map<GetTypeCars>(types);
    }

    #endregion
    
    #region Delete

    public async Task<GetCarsDto> DeleteCars(int id)
    {
        var car = await _carRepository.GetByIdAsync(id);
        if (car != null)
        {
            _carRepository.Delete(car);
        }

        return _mapper.Map<GetCarsDto>(car);
    }

    public async Task<GetCarsBrandDto> DeleteBrand(int id)
    {
        var brand = await _brandRepository.GetByIdAsync(id);
        if (brand != null)
        {
            _brandRepository.Delete(brand);
        }

        return _mapper.Map<GetCarsBrandDto>(brand);
    }

    public async Task<GetTypeCars> DeleteType(int id)
    {
        var type = await _typeRepository.GetByIdAsync(id);
        if (type != null)
        {
            _typeRepository.Delete(type);
        }

        return _mapper.Map<GetTypeCars>(type);
    }

    #endregion

    #region GetAll

    public async Task<IEnumerable<GetCarsDto>> GetCars()
        => _mapper.Map<IEnumerable<GetCarsDto>>(await _carRepository.ListAllAsync());

    public async Task<IEnumerable<GetCarsBrandDto>> GetCarsBrands()
        => _mapper.Map<IEnumerable<GetCarsBrandDto>>(await _brandRepository.ListAllAsync());

    public async Task<IEnumerable<GetTypeCars>> GetCarsType()
        => _mapper.Map<IEnumerable<GetTypeCars>>(await _typeRepository.ListAllAsync());

   

    #endregion

    
}