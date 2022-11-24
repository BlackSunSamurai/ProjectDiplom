using AutoMapper;
using CarsShop.Bll.Interfaces;
using CarsShop.Common.DTO.Cart;
using CarsShop.Dal;
using CarsShop.Dal.Interfaces;
using CarsShop.Domain.Cart;
using Microsoft.EntityFrameworkCore;

namespace CarsShop.Bll.Services;

public class CartService : ICartService
{
    private readonly IRepository<UserCart> _repository;
    private readonly IMapper _mapper;
    private readonly IRepository<CartItem> _itemRepository;
    private readonly CarShopDbContext _context;

    public CartService(IRepository<UserCart> repository, IMapper mapper, IRepository<CartItem> itemRepository, CarShopDbContext context)
    {
        _repository = repository;
        _mapper = mapper;
        _itemRepository = itemRepository;
        _context = context;
    }

    public async Task<GetCartDto> GetCartById(string id)
    {
        var cart = await _context
            .UserCarts
            .Include(x => x.Item)
            .FirstOrDefaultAsync(x => x.Guid.ToString() == id);
        
            return _mapper.Map<GetCartDto>(cart);
    }

    public async Task<UserCart> CreateCart()
    {
        var cart = new UserCart
        {
            Guid = Guid.NewGuid()
        };

        await _repository.AddAsync(cart);
        await _repository.SaveChangesAsync();
        
        return await _repository
            .GetByIdWithInclude<UserCart>(cart.Id,x => x.Item);
    }

    public async Task<GetCartDto> UpdateCart(GetCartDto cart)
    {
        var cartId = await _repository.GetByIdAsync(cart.Id);
        
        if (cartId != null)
        {
            _repository.Delete(cartId);
        }

        var cartRepo = await _repository.GetByIdAsync(cart.Id);

        if (cartRepo == null)
        {
            throw new Exception("This cart has not exist in database");
        }
            

        var itemsToAdd = _mapper.Map<List<CartItem>>(cart.Item);
        foreach (var item in itemsToAdd)
        {
            cartRepo.Item.Add(item);
        }

        _repository.Update(cartRepo);
            
        await _repository.SaveChangesAsync();

        return _mapper.Map<GetCartDto>(cartRepo);
    }

    public async Task DeleteCartAsync(int id)
    {
        var cart = await _repository
            .GetByIdWithInclude<UserCart>(id, x => x.Item);

        foreach (var item in cart.Item)
        {
            _itemRepository.Delete(item);
        }

        _repository.Delete(cart);

        await _repository.SaveChangesAsync();
    }
}