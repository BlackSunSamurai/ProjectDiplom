using CarsShop.Common.DTO.Cart;
using CarsShop.Domain.Cart;

namespace CarsShop.Bll.Interfaces;

public interface ICartService
{
    public Task<GetCartDto> GetCartById(string id);
    public Task<UserCart> CreateCart();
    public Task<GetCartDto> UpdateCart(GetCartDto cart);
    public Task DeleteCartAsync(int id);
}