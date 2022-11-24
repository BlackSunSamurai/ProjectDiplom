using AutoMapper;
using CarsShop.Bll.Interfaces;
using CarsShop.Common.DTO.Transaction;
using CarsShop.Dal.Interfaces;
using CarsShop.Domain.Card;

namespace CarsShop.Bll.Services;

public class TransactionService : ITransactionService
{
    private readonly IRepository<Transaction> _repository;
    private readonly IMapper _mapper;

    public TransactionService(IRepository<Transaction> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateTransactionAsync(string userId, decimal price, TransactionType type)
    {
        var transaction = new Transaction();
        transaction.UserId = userId;
        transaction.Price = price;
        transaction.Type = type;
        transaction.CreatedAt = DateTime.Now;

        await _repository.AddAsync(transaction);
        await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<GetTransaction>> GetAllTransactionsById(string id)
    {
        var list = await _repository.ListAllAsync();
        return _mapper.Map<IEnumerable<GetTransaction>>(list
            .Where(x => x.UserId == id));
    }
}