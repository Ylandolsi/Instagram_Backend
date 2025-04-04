namespace Instagram_Backend.Exceptions;
public class BadRequestException : ApiException
{
    public BadRequestException(string message) 
        : base(message, 400)
    {
    }
}