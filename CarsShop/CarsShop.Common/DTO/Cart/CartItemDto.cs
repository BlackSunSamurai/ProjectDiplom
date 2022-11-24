using System.ComponentModel.DataAnnotations;

namespace CarsShop.Common.DTO.Cart;

public class CartItemDto
{
    [Required]
    public int CarId { get; set; }
        
    [Required]
    public string Name { get; set; }

    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; }

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }

    [Required]
    public string PictureUrl { get; set; }

    [Required]
    public string Brand { get; set; }

    [Required]
    public string Type { get; set; } 
}