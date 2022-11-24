
using CarsShop.Domain;

namespace CarsShop.Dal.Seed;

public class CarBrandSeed
{
    public static async Task Seed(CarShopDbContext context)
    {
        if (!context.CarBrands.Any())
        {
            var brandOne = new CarBrand
            {
                Name = "BMW"
            };
            var brandTwo = new CarBrand
            {
                Name = "Ferrari"
            };
            var brandThree = new CarBrand
            {
                Name = "Toyota"
            };
            var brandFour = new CarBrand
            {
                Name = "Mazda"
            };
            var brandFive = new CarBrand
            {
                Name = "Suzuki"
            };

            context.CarBrands.Add(brandOne);
            context.CarBrands.Add(brandTwo);
            context.CarBrands.Add(brandThree);
            context.CarBrands.Add(brandFour);
            context.CarBrands.Add(brandFive);

            await context.SaveChangesAsync();
        }
    }
}