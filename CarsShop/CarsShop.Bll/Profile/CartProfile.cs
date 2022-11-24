using CarsShop.Common.DTO.Cart;
using CarsShop.Domain.Cart;

namespace CarsShop.Bll.Profile;

public class CartProfile : AutoMapper.Profile
{
    public CartProfile()
    {
        CreateMap<GetCartDto, UserCart>();
        CreateMap<UserCart,GetCartDto>();
    }
}