using CarsShop.Dal.Repository;
using CarsShop.Domain.Order;

namespace CarsShop.Dal.Specification
{
    public class OrdersWithItemsAndOrderingSpecification : Specification<Order>
    {
        public OrdersWithItemsAndOrderingSpecification(string email) : base(o => o.UserEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrdersWithItemsAndOrderingSpecification(int id, string email) : base(o => o.Id == id && o.UserEmail == email)
        {
            AddInclude(o => o.OrderItems);
        }
    }
}