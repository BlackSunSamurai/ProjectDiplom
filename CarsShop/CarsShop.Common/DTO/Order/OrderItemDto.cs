namespace CarsShop.Common.DTO.Order
{
    public class OrderItemDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}