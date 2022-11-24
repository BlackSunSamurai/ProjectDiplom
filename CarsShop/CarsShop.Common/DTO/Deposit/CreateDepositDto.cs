using System.ComponentModel.DataAnnotations;

namespace Shop.Common.DTOs.Deposit;

public class CreateDepositDto
{
    [Required]
    [Range(10.00, 10000.00)]
    public decimal Amount { get; set; }

    [Required]
    public string CreditCardId { get; set; }
}