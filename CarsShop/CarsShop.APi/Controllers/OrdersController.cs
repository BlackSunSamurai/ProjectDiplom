using System.Net;
using System.Security.Claims;
using AutoMapper;
using CarsShop.Bll.Interfaces;
using CarsShop.Common.DTO.Order;
using CarsShop.Common.Exceptions;
using CarsShop.Domain;
using CarsShop.Domain.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsShop.APi.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;

        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var address = _mapper.Map<Address>(orderDto.Address);

            var order = await _orderService.CreateOrderAsync(email, orderDto.CartId,orderDto.DeliveryId,address);

            if (order == null)
            {
                return BadRequest(new RestException(HttpStatusCode.BadRequest, "Problem create order"));
            }
            
            return Created(nameof(CreateOrder),order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReturnDto>>> GetOrdersForUser()
        {
            var email = HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var orders = await _orderService.GetOrdersForUserAsync(email);

            return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderReturnDto>>(orders));
        }

        [HttpGet("{id:int}")]
         public async Task<ActionResult<OrderReturnDto>> GetOrderById(int id)
        {
            var email = HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var order = await _orderService.GetOrderByIdAsync(id, email);

            if(order == null)
                return NotFound(new RestException(HttpStatusCode.NotFound,"Order has not found"));

            return _mapper.Map<Order, OrderReturnDto>(order);
        }
         
         [HttpGet("{delivery}")]
         public async Task<ActionResult<IEnumerable<Delivery>>> GetDelivery() 
             => Ok(await _orderService.GetDeliveryAsync());
         
        
    }
}