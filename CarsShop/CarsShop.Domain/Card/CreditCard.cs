using CarsShop.Domain.Auth;

namespace CarsShop.Domain.Card;

public class CreditCard : BaseEntity
{
    public string Number { get; set; }

    public string CVV { get; set; }

    public DateTime DateRegistered { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }
}