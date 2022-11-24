using CarsShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarsShop.Dal.Configuration;

public class CarConfig : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Price).HasColumnType("decimal(18,4)");
        builder.Property(p => p.PhotoUrl).IsRequired();
        builder.Property(p => p.Mileage).IsRequired();
        builder.Property(p => p.Year).IsRequired();
        builder.HasOne(b => b.CarBrand).WithMany()
            .HasForeignKey(p => p.CarBrandId);
        builder.HasOne(t => t.CarType).WithMany()
            .HasForeignKey(p => p.CarTypeId);
    }
}