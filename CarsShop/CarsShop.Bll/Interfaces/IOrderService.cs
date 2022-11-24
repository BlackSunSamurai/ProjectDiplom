using CarsShop.Domain;
using CarsShop.Domain.Order;

namespace CarsShop.Bll.Interfaces;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(string userEmail, int cartId,int deliveryId, Address address);

    Task<IEnumerable<Order>> GetOrdersForUserAsync(string userEmail);

    Task<Order> GetOrderByIdAsync(int id, string userEmail);
    Task<IEnumerable<Delivery>> GetDeliveryAsync();
}