namespace DEVinCer.Domain.Exceptions;

public class AutenticationException : Exception
{
    public AutenticationException(string error) : base(error)
    {
        
    }
}
