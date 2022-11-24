namespace CarsShop.Common.DTO.Order
{
    public class OrderReturnDto
    {
        public int Id { get; set; }
        public Domain.Address Address { get; set; }
        public string UserEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}