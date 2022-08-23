using ValueObjects101.Domain.Shared.Enums;
using ValueObjects101.Domain.Shared.Exceptions;

namespace ValueObjects101.Domain.Shared.ValueObjects;

/**
 * NOTE: Creating 'Value' property without 'init' prevents from using 'with' keyword which can omits validation:
 * public int Value { get; init; }
 * Quantity quantity = new(1);
 * var invalidQuantity = quantity with { Value = 0 }; 
 */
public record Quantity(double Value, Unit Unit)
{
    public double Value { get; } = IsValid(Value, Unit) ? Value : throw new InvalidQuantityException(Value, Unit);

    public static bool IsValid(double value, Unit unit)
    {
        if (value < 0.0)
            return false;

        if (unit == Unit.Pieces && Math.Abs(value % 1) > double.Epsilon * 100.0)
            return false;

        return true;
    }
}
