namespace DEVinCer.Domain.Exceptions;

public class NotAcceptableException : Exception
{
    public NotAcceptableException(string error) : base(error)
    {
        
    }
}
