namespace CarsShop.Common.DTO.Car;

public class CreateCar
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }
    public string CarType { get; set; }
    public string CarBrand { get; set; }
}