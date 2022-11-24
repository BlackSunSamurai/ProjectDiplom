using CarsShop.Domain.Card;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarsShop.Dal.Configuration;

public class DepositConfig : IEntityTypeConfiguration<Deposit>
{
    public void Configure(EntityTypeBuilder<Deposit> builder)
    {
        builder
            .HasOne(d => d.User)
            .WithMany(c => c.Deposits)
            .HasForeignKey(d => d.UserId);
    }
}