using CarsShop.Common.DTO.Order;
using CarsShop.Domain.Order;

namespace CarsShop.Bll.Profile;

public class OrderProfile : AutoMapper.Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderReturnDto>();
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.CarId, o =>
                o.MapFrom(s => s.CarItemOrdered.CarItemId))
            .ForMember(d => d.CarName, o =>
                o.MapFrom(s => s.CarItemOrdered.CarName))
            .ForMember(d => d.PictureUrl, o =>
                o.MapFrom(s => s.CarItemOrdered.CarUrl));
    }
}