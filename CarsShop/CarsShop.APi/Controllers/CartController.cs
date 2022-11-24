
using CarsShop.Bll.Interfaces;
using CarsShop.Common.DTO.Cart;
using CarsShop.Domain.Cart;
using Microsoft.AspNetCore.Mvc;

namespace CarsShop.APi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<GetCartDto>> GetCartById(string id)
        {
            var cart = await _cartService.GetCartById(id);

            if (cart != null)
            {
                return Ok(cart);
            }
            
            return BadRequest("Errors to cart download");
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UserCart>> CreateCart()
            => Ok(await _cartService.CreateCart());

        [HttpPost("Update")]
        public async Task<ActionResult<UserCart>> UpdateCart(GetCartDto cart)
            => Ok(await _cartService.UpdateCart(cart));

        [HttpDelete("{id}")]
        public async Task DeleteCartAsync(int id)
            => await _cartService.DeleteCartAsync(id);
    }
}