namespace CarsShop.Domain;

public class Car : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }
    
    public CarBrand CarBrand { get; set; }
    public int CarBrandId { get; set; }
    
    public CarType CarType { get; set; }
    public int CarTypeId { get; set; }
}