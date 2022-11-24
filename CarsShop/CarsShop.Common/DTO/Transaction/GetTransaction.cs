using CarsShop.Domain.Card;

namespace CarsShop.Common.DTO.Transaction;

public class GetTransaction
{
    public DateTime CreatedAt { get; set; }

    public decimal Price { get; set; }

    public TransactionType Type { get; set; }
}