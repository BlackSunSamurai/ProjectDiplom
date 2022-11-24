using CarsShop.Common.DTO.Address;
using CarsShop.Domain.Auth;

namespace CarsShop.Bll.Profile;

public class AddressProfile : AutoMapper.Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressDto>();
        CreateMap<AddressDto,Address>();
    }
}