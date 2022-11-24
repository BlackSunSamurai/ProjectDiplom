using System.Net;

namespace CarsShop.Common.Exceptions;

public class RestException : Exception
{
    public HttpStatusCode Code { get; }
    public object? Errors { get; }
    public RestException(HttpStatusCode code, object? errors = null)
    {
        this.Errors = errors;
        this.Code = code;
    }
}