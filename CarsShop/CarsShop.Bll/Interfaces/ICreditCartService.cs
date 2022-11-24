using Shop.Common.DTOs.CreditCard;

namespace CarsShop.Bll.Interfaces;

public interface ICreditCartService
{
    Task<int> Create(CreateCreditCardDto card, string username);

    Task<IEnumerable<GetCard>> GetAllCreditCardsAsync(string userId);
}