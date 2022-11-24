using CarsShop.Domain;
using CarsShop.Domain.Auth;
using CarsShop.Domain.Card;
using CarsShop.Domain.Cart;
using CarsShop.Domain.Order;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarsShop.Dal;

public class CarShopDbContext : IdentityDbContext<User>
{
    public CarShopDbContext(DbContextOptions<CarShopDbContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarBrand> CarBrands{ get; set; }
    public DbSet<CarType> CarTypes { get; set; }
    public DbSet<UserCart> UserCarts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<Deposit> Deposits { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Delivery> Delivery { get; set; }
}