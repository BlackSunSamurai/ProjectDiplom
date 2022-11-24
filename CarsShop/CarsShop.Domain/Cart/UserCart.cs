namespace CarsShop.Domain.Cart;

public class UserCart : BaseEntity
{
    public Guid Guid { get; set; }
    public List<CartItem> Item { get; set; }
}