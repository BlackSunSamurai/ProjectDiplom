using CarsShop.Common.DTO.Address;

namespace CarsShop.Common.DTO.Order
{
    public class OrderDto
    {
        public int CartId { get; set; }
        public int DeliveryId { get; set; }
        public AddressDto Address { get; set; }
    }
}