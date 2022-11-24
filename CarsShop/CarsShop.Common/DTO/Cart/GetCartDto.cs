using CarsShop.Domain.Cart;

namespace CarsShop.Common.DTO.Cart;

public class GetCartDto
{
    public int Id { get; set; }
    public string Guid { get; set; }
    public List<CartItemDto> Item { get; set; }
}