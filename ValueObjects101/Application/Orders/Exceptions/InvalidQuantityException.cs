using ValueObjects101.Domain.Shared.Exceptions;

namespace ValueObjects101.Application.Orders.Exceptions;

public class InvalidQuantityException : ValueObjects101Exception
{
    public InvalidQuantityException(int quantity)
        : base($"Invalid quantity '{quantity}'")
    {
    }
}