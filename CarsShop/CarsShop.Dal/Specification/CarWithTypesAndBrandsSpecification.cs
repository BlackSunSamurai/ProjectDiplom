using CarsShop.Dal.Repository;
using CarsShop.Domain;

namespace CarsShop.Dal.Specification
{
    public class CarWithTypesAndBrandsSpecification : Specification<Car>
    {
        public CarWithTypesAndBrandsSpecification(CarSpecParams carParams) 
            : base(x => 
                (string.IsNullOrEmpty(carParams.Search) || x.Name.ToLower().Contains(carParams.Search)) &&
                (!carParams.BrandId.HasValue || x.CarBrandId == carParams.BrandId) &&
                (!carParams.TypeId.HasValue || x.CarTypeId == carParams.TypeId)
            )
        {
            AddInclude(x => x.CarType);
            AddInclude(x => x.CarBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(carParams.PageSize * (carParams.PageIndex - 1), carParams.PageSize);

            if (!string.IsNullOrEmpty(carParams.Sort))
            {
                switch (carParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public CarWithTypesAndBrandsSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.CarType);
            AddInclude(x => x.CarBrand);
        }
    }
}