using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarsShop.Bll.Interfaces;
using CarsShop.Common.Exceptions;
using CarsShop.Dal.Interfaces;
using CarsShop.Domain.Auth;
using CarsShop.Domain.Card;
using Microsoft.AspNetCore.Identity;
using Shop.Bll.Interfaces;
using Shop.Common.DTOs.CreditCard;

namespace CarsShop.Bll.Services;

public class CreditCardService : ICreditCartService
{
    private readonly IRepository<CreditCard> _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public CreditCardService(IRepository<CreditCard> repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }


    public async Task<int> Create(CreateCreditCardDto card, string username)
    {
        Common.Validation.Validator.ThrowIfNull(card);

        var client = await _userManager.FindByNameAsync(username);
        
        Common.Validation.Validator.ThrowIfNull(client,new CrudExceptions("User has not found"));
        
        var creditCard = _mapper.Map<CreditCard>(card);
        creditCard.UserId = client.Id;
        creditCard.DateRegistered = DateTime.Now;

        await _repository.AddAsync(creditCard);
        await _repository.SaveChangesAsync();

        return creditCard.Id;
    }
    
    public async Task<IEnumerable<GetCard>> GetAllCreditCardsAsync(string userId)
    {
        var list = await _repository.ListAllAsync();
        return _mapper.Map<IEnumerable<GetCard>>(list
            .Where(x => x.UserId == userId)
            .ToList());
    }
}