using System.ComponentModel.DataAnnotations;

namespace CarsShop.Domain.Auth
{
    public class Address : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        [Required]
        public string UserId { get; set; }
        public User AppUser { get; set; }
    }
}