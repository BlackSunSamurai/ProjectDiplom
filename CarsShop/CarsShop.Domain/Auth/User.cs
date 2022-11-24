using CarsShop.Domain.Card;
using Microsoft.AspNetCore.Identity;

namespace CarsShop.Domain.Auth
{
    public class User : IdentityUser
    {
        public decimal Balance { get; set; }
        public IEnumerable<Order.Order> Orders { get; set; } = new List<Order.Order>();

        public Address Address { get; set; }
        
        public IEnumerable<CreditCard> CreditCards { get; set; }

        public IEnumerable<Deposit> Deposits { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}