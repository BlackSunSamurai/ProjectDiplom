namespace CarsShop.Domain.Order
{
    public class CarItemOrdered
    {
        public int CarItemId { get; set; }
        public string CarName { get; set; }
        public string CarUrl { get; set; }
        
        public CarItemOrdered()
        {
        }

        public CarItemOrdered(int carItemId, string carName, string carUrl)
        {
            CarItemId = carItemId;
            CarName = carName;
            CarUrl = carUrl;
        }
    }
}