using CarsShop.Domain.Auth;

namespace CarsShop.Domain.Order;

public class OrderItem : BaseEntity
{
    public CarItemOrdered CarItemOrdered { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public OrderItem()
    {
    }

    public OrderItem(CarItemOrdered carItemOrdered, decimal price, int quantity)
    {
        CarItemOrdered = carItemOrdered;
        Price = price;
        Quantity = quantity;
    }
}