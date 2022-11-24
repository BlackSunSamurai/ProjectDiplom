using CarsShop.Domain;

namespace CarsShop.Dal.Seed;

public class DeliverySeed
{
    public static async Task Seed(CarShopDbContext context)
    {
        if (!context.Delivery.Any())
        {
            var deliveryOne = new Delivery
            {
                Name = "SpedsGroup",
                DeliveryTime = "1 week",
                Description = "More fast for more people",
                Price = 1500
            };
            var deliveryTwo = new Delivery
            {
                Name = "Limit Ltd",
                DeliveryTime = "1 week - 2 week",
                Description = "Dont type",
                Price = 3000
            };
            var deliveryThree = new Delivery
            {
                Name = "Go",
                DeliveryTime = "5 days - 1 week",
                Description = "For desc",
                Price = 5000
            };

            context.Delivery.Add(deliveryOne);
            context.Delivery.Add(deliveryTwo);
            context.Delivery.Add(deliveryThree);

            await context.SaveChangesAsync();
        }
    }
}