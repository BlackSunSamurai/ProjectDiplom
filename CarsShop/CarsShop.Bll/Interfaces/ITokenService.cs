using CarsShop.Domain.Auth;

namespace CarsShop.Bll.Interfaces;

public interface ITokenService
{
    public string CreateToken(User user);
}