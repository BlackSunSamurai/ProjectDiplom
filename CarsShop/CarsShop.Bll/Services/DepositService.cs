using AutoMapper;
using CarsShop.Bll.Interfaces;
using CarsShop.Common.Validation;
using CarsShop.Dal.Interfaces;
using CarsShop.Domain.Auth;
using CarsShop.Domain.Card;
using Microsoft.AspNetCore.Identity;
using Shop.Bll.Interfaces;
using Shop.Common.DTOs.Deposit;

namespace CarsShop.Bll.Services;

public class DepositService : IDepositService
{

    private readonly ITransactionService _service;
    private readonly IRepository<Deposit> _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public DepositService(ITransactionService service, IRepository<Deposit> repository, IMapper mapper, UserManager<User> userManager)
    {
        _service = service;
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task CreateDepositAsync(CreateDepositDto depositDto, string username)
    {
        Validator.ThrowIfNull(depositDto);
        Validator.ThrowIfNull(username);

        if (depositDto.Amount < 0)
        {
            throw new ArgumentNullException();
        }

        var user = await _userManager.FindByNameAsync(username);

        var deposit = _mapper.Map<Deposit>(depositDto);
        deposit.UserId = user.Id;
        deposit.CreatedAt = DateTime.Now;

        user.Balance += depositDto.Amount;

        await _service.CreateTransactionAsync(user.Id, depositDto.Amount, TransactionType.Deposit);

        await _repository.AddAsync(deposit);
        await _repository.SaveChangesAsync();
    }
}