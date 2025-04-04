namespace Instagram_Backend.Exceptions;


public class UnauthorizedException : ApiException
{
    public UnauthorizedException(string message) 
        : base(message, 401)
    {
    }
}

