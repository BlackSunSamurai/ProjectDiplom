namespace CarsShop.Domain.Order;

public class Order : BaseEntity
{
    
    public string UserEmail { get; set; }
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public IEnumerable<OrderItem> OrderItems { get; set; }
    public decimal Subtotal { get; set; }
        
    public string Status { get; set; } = "Pending";
    
    public Address Address { get; set; }
    public Delivery Delivery { get; set; }

    public decimal Total()
    {
        return Subtotal + Delivery.Price;
    }

    public Order(string userEmail, IEnumerable<OrderItem> orderItems, decimal subtotal,
        Delivery delivery,Address address)
    {
        UserEmail = userEmail;
        OrderItems = orderItems;
        Subtotal = subtotal;
        Delivery = delivery;
        Address = address;
    }

    public Order()
    {
    }
}