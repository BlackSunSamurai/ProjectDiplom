using CarsShop.Domain.Auth;

namespace CarsShop.Domain.Card;

public class Transaction : BaseEntity
{
    public DateTime CreatedAt { get; set; }

    public decimal Price { get; set; }

    public TransactionType Type { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }
}