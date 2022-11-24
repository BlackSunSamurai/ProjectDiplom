using System.Net;
using CarsShop.Bll.Interfaces;
using CarsShop.Common.Exceptions;
using CarsShop.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Bll.Interfaces;
using Shop.Common.DTOs.CreditCard;

namespace CarsShop.APi.Controllers;

[Route("api/creditcart")]
public class CreditCartController : BaseController
{
    private ICreditCartService _creditCardService;
    private UserManager<User> _userManager;

    public CreditCartController(ICreditCartService creditCardService, UserManager<User> userManager)
    {
        _creditCardService = creditCardService;
        _userManager = userManager;
    }
    
    [HttpPost]
    public async Task<ActionResult<string>> Create(CreateCreditCardDto model)
    {
        if (!ModelState.IsValid)
        {
            throw new RestException(HttpStatusCode.BadRequest, "Model has no valid");
        }

        await _creditCardService.Create(model, User.Identity?.Name);

        return model.Number;
    }

    [HttpGet]
    public async Task<IEnumerable<GetCard>>GetAllCards()
    {
        string userId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;
        var creditCards = await _creditCardService.GetAllCreditCardsAsync(userId);
        return creditCards;
    }
}