using CarsShop.Bll.Interfaces;
using CarsShop.Dal;
using CarsShop.Dal.Interfaces;
using CarsShop.Dal.Specification;
using CarsShop.Domain;
using CarsShop.Domain.Cart;
using CarsShop.Domain.Order;
using Microsoft.EntityFrameworkCore;

namespace CarsShop.Bll.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _repository;
    private readonly IRepository<Car> _carItemRepository;
    private readonly IRepository<UserCart> _userCartRepository;
    private readonly IRepository<Delivery> _deliveryRepository;
    private readonly CarShopDbContext _carShopDbContext;


    public OrderService(IRepository<Order> repository, IRepository<Car> carItemRepository, IRepository<UserCart> userCartRepository, IRepository<Delivery> deliveryRepository, CarShopDbContext carShopDbContext)
    {
        _repository = repository;
        _carItemRepository = carItemRepository;
        _userCartRepository = userCartRepository;
        _deliveryRepository = deliveryRepository;
        _carShopDbContext = carShopDbContext;
    }

    public async Task<Order> CreateOrderAsync(string userEmail, int cartId,int deliveryId, Address address)
    {
        /*var cart = await _userCartRepository
            .GetByIdWithInclude<UserCart>(cartId, x => x.Item);*/
        
        var cartRef = await _carShopDbContext
            .UserCarts
            .Include(x => x.Item)
            .FirstOrDefaultAsync(x => x.Id == cartId);

        var items = new List<OrderItem>();
        foreach (var item in cartRef.Item)
        {
            var carItem = await _carItemRepository.GetByIdAsync(item.CarId);
            var itemOrdered = new CarItemOrdered(carItem.Id, carItem.Name, carItem.PhotoUrl);
            var orderItem = new OrderItem(itemOrdered, carItem.Price, item.Quantity);
            items.Add(orderItem);
        }
        var delivery = await _deliveryRepository.GetByIdAsync(deliveryId);
        
        var subtotal = items.Sum(item => item.Price * item.Quantity);

        var order = new Order(userEmail,items,subtotal,delivery,address);

        await _repository.AddAsync(order);

        await _repository.SaveChangesAsync();
        
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersForUserAsync(string userEmail)
    {
        var spec = new OrdersWithItemsAndOrderingSpecification(userEmail);

        return await _repository.ListAsync(spec);
    }

    public async Task<Order> GetOrderByIdAsync(int id, string userEmail)
    {
        var spec = new OrdersWithItemsAndOrderingSpecification(id, userEmail);

        return await _repository.GetEntityWithSpec(spec);
    }

    public async Task<IEnumerable<Delivery>> GetDeliveryAsync()
        => await _deliveryRepository.ListAllAsync();
}