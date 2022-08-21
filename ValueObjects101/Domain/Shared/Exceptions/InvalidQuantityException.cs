namespace ValueObjects101.Domain.Shared.Exceptions;

public class InvalidQuantityException : ValueObjects101Exception
{
    public InvalidQuantityException(int quantity)
        : base($"Invalid quantity '{quantity}'")
    {
    }
}
