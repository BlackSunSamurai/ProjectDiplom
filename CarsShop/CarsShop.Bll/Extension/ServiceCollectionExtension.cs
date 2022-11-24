using System.Reflection;
using DressShops.Bll.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CarsShop.Bll.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        Assembly
            .GetAssembly(typeof(IService))
            ?.GetTypes()
            .Where(t => t.IsClass &&
                        t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
            .Select(t => new
            {
                Interface = t.GetInterface($"I{t.Name}"),
                Implementation = t
            })
            .ToList()
            .ForEach(s => services.AddScoped(s.Interface, s.Implementation));

        return services;
    }
}