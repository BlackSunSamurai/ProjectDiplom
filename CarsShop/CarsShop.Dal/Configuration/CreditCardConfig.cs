using CarsShop.Domain.Card;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarsShop.Dal.Configuration;

public class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder
            .HasOne(cc => cc.User)
            .WithMany(c => c.CreditCards)
            .HasForeignKey(cc => cc.UserId);
    }
}