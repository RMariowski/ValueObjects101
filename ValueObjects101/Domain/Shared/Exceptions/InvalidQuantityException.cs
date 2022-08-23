using ValueObjects101.Domain.Shared.Enums;

namespace ValueObjects101.Domain.Shared.Exceptions;

public class InvalidQuantityException : ValueObjects101Exception
{
    public InvalidQuantityException(double quantity, Unit unit)
        : base($"Invalid quantity '{quantity}' of unit '{unit}'")
    {
    }
}
