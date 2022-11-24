using CarsShop.Domain;

namespace CarsShop.Dal.Seed;

public class CarTypeSeed
{
    public static async Task Seed(CarShopDbContext context)
    {
        if (!context.CarTypes.Any())
        {
            var carTypeOne = new CarType
            {
                Name = "Sedan"
            };
            var carTypeTwo = new CarType
            {
                Name = "Hatchback"
            };
            var carTypeThree = new CarType
            {
                Name = "Coupe"
            };
            var carTypeFour = new CarType
            {
                Name = "Universal"
            };

            context.CarTypes.Add(carTypeOne);
            context.CarTypes.Add(carTypeTwo);
            context.CarTypes.Add(carTypeThree);
            context.CarTypes.Add(carTypeFour);

            await context.SaveChangesAsync();
        }
    }
}