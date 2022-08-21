namespace ValueObjects101.Domain.Shared.Exceptions;

public class InvalidEmailException : ValueObjects101Exception
{
    public InvalidEmailException(string? email)
        : base($"Invalid email '{email}'")
    {
    }
}
