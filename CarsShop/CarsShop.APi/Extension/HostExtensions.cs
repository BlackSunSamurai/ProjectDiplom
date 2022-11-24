using CarsShop.Dal;
using CarsShop.Dal.Seed;

namespace CarsShop.APi.Extension;

public static class HostExtensions
{
    public static async Task SeedData(this IHost host)
    {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<CarShopDbContext>();

                    await SeedFacade.SeedData(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
        }
    }