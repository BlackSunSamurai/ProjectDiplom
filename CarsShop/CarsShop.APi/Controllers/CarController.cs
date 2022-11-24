using System.Net;
using AutoMapper;
using CarsShop.Bll.Interfaces;
using CarsShop.Common.DTO.BrandCars;
using CarsShop.Common.DTO.Car;
using CarsShop.Common.DTO.TypeCars;
using CarsShop.Common.Exceptions;
using CarsShop.Common.Pagination;
using CarsShop.Dal.Interfaces;
using CarsShop.Dal.Specification;
using CarsShop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CarsShop.APi.Controllers;

public class CarController : BaseController
{
    private readonly ICarService _carService;
    private readonly IRepository<Car> _repository;
    private readonly IMapper _mapper;

    public CarController(ICarService carService, IRepository<Car> repository, IMapper mapper)
    {
        _carService = carService;
        _repository = repository;
        _mapper = mapper;
    }

    #region Create

    [HttpPost]
    public async Task<GetCarsDto> CreateCar(CreateCar car)
        => await _carService.CreateCar(car);

    [HttpPost("carbrands")]
    public async Task<GetCarsBrandDto> CreateBrand(CreateBrand brand)
        => await _carService.CreateBrand(brand);

    [HttpPost("cartypes")]
    public async Task<GetTypeCars> CreateType(CreateType type)
        => await _carService.CreateType(type);
    #endregion
    
    #region Delete

    [HttpDelete("{id}")]
    public async Task<GetCarsBrandDto> DeleteBrand(int id)
        => await _carService.DeleteBrand(id);

    [HttpDelete("carbrands/{id}")]
    public async Task<GetCarsDto> DeleteCar(int id)
        => await _carService.DeleteCars(id);

    [HttpDelete("cartypes/{id}")]
    public async Task<GetTypeCars> DeleteTypeCar(int id)
        => await _carService.DeleteType(id);

    #endregion

    #region Get

    [HttpGet("types")]
    public async Task<ActionResult<IEnumerable<GetTypeCars>>> GetAllCarType()
        => Ok(await _carService.GetCarsType());

    [HttpGet("brands")]
    public async Task<ActionResult<IEnumerable<GetCarsBrandDto>>> GetAllBrandType()
        => Ok(await _carService.GetCarsBrands());

    [HttpGet("allcars")]
    public async Task<ActionResult<IEnumerable<GetCarsDto>>> GetAllCar()
        => Ok(await _carService.GetCars());
    
    [HttpGet]
    public async Task<ActionResult<Pagination<GetCarsDto>>> GetCar(
        [FromQuery]CarSpecParams carParams)
    {
        var spec = new CarWithTypesAndBrandsSpecification(carParams);

        var countSpec = new CarWithFiltersForCountSpecificication(carParams);

        var totalItems = await _repository.CountAsync(countSpec);

        var products = await _repository.ListAsync(spec);

        var data = _mapper
            .Map<IEnumerable<Car>, IEnumerable<GetCarsDto>>(products);

        return Ok(new Pagination<GetCarsDto>(carParams.PageIndex, carParams.PageSize, totalItems,
            data));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<GetCarsDto>> GetCarsById(int id)
    {
        var spec = new CarWithTypesAndBrandsSpecification(id);

        var car = await _repository.GetEntityWithSpec(spec);

        if (car == null) 
            return NotFound(new RestException(HttpStatusCode.NotFound,"Car has not found"));

        return _mapper.Map<Car, GetCarsDto>(car);
    }

    #endregion
    

}