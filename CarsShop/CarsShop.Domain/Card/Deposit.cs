using CarsShop.Domain.Auth;

namespace CarsShop.Domain.Card;

public class Deposit : BaseEntity
{
    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public string UserId { get; set; }
    public User User { get; set; }
}