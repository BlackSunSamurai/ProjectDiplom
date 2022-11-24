using CarsShop.Common.DTO.Transaction;
using CarsShop.Domain.Card;

namespace CarsShop.Bll.Interfaces;

public interface ITransactionService
{
    Task CreateTransactionAsync(string userId, decimal price, TransactionType type);

    Task<IEnumerable<GetTransaction>> GetAllTransactionsById(string id);
}