namespace CarsShop.Common.Exceptions;

public class CrudExceptions : Exception
{
    public CrudExceptions(string? message) : base(message)
    {
    }
}