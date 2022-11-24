namespace CarsShop.Dal.Seed;

public class SeedFacade
{
    public static async Task SeedData(CarShopDbContext context)
    {
        await DeliverySeed.Seed(context);
        await CarBrandSeed.Seed(context);
        await CarTypeSeed.Seed(context);
        await CarSeed.Seed(context);
    }
}