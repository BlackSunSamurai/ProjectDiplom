using CarsShop.Domain;

namespace CarsShop.Dal.Seed;

public class CarSeed
{
    public static async Task Seed(CarShopDbContext context)
    {
        if (!context.Cars.Any())
        {
            var carOne = new Car
            {
                Name = "Toyota Supra",
                Description = "Test",
                Price = 20000,
                CarTypeId = 2,
                CarBrandId = 3,
                PhotoUrl = "assets/image/picOne.jpg",
                Mileage = 0,
                Year = 2012
                
            };
            var carTwo = new Car
            {
                Name = "BMW X5",
                Description = "Test",
                Price = 50000,
                CarTypeId = 1,
                CarBrandId = 1,
                PhotoUrl = "assets/image/picTwo.jpg",
                Mileage = 0,
                Year = 2017
            };
            var carThree = new Car
            {
                Name = "Suzuki 4x4",
                Description = "Test",
                Price = 35000,
                CarTypeId = 2,
                CarBrandId = 5,
                PhotoUrl = "assets/image/picThree.jpg",
                Mileage = 0,
                Year = 2012
            };
            var carFour = new Car
            {
                Name = "Mazda 323",
                Description = "Test",
                Price = 45000,
                CarTypeId = 4,
                CarBrandId = 4,
                PhotoUrl = "assets/image/picFour.jpg",
                Mileage = 0,
                Year = 2017
            };

            context.Cars.Add(carOne);
            context.Cars.Add(carTwo);
            context.Cars.Add(carThree);
            context.Cars.Add(carFour);

            await context.SaveChangesAsync();
        }
    }
}