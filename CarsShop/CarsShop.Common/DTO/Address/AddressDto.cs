using System.ComponentModel.DataAnnotations;

namespace CarsShop.Common.DTO.Address
{
    public class AddressDto
    {
        [Required]
        [StringLength(maximumLength:25,MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength:25,MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength:40,MinimumLength = 8)]
        public string Street { get; set; }

        [Required]
        [StringLength(maximumLength:20,MinimumLength = 5)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }
    }
}