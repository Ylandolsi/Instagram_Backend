
namespace Instagram_Backend.Exceptions;
public class InvalidOpException : ApiException
{
    public InvalidOpException(string message) 
        : base(message, 409)
    {
    }
}