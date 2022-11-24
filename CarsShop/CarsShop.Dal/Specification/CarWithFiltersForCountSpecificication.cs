using CarsShop.Dal.Repository;
using CarsShop.Domain;

namespace CarsShop.Dal.Specification
{
    public class CarWithFiltersForCountSpecificication : Specification<Car>
    {
        public CarWithFiltersForCountSpecificication(CarSpecParams carParams) 
            : base(x => 
                (string.IsNullOrEmpty(carParams.Search) || x.Name.ToLower().Contains(carParams.Search)) &&
                (!carParams.BrandId.HasValue || x.CarBrandId == carParams.BrandId) &&
                (!carParams.TypeId.HasValue || x.CarTypeId == carParams.TypeId)
            )
        {
        }
    }
}