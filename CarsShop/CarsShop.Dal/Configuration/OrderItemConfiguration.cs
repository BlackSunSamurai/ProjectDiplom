using CarsShop.Domain.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarsShop.Dal.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(i => i.CarItemOrdered, 
                io => { io.WithOwner();});

            builder.Property(i => i.Price).HasColumnType("decimal(18,2)");
        }
    }
}