using ValueObjects101.Domain.Shared.Exceptions;

namespace ValueObjects101.Domain.Shared.ValueObjects;

/**
 * NOTE: Creating 'Value' property without 'init' prevents from using 'with' keyword which can omits validation:
 * public int Value { get; init; }
 * Quantity quantity = new(1);
 * var invalidQuantity = quantity with { Value = 0 }; 
 */
public record Quantity(double Value)
{
    public double Value { get; } = IsValid(Value) ? Value : throw new InvalidQuantityException(Value);

    public static bool IsValid(double value)
    {
        return value > 0;
    }
}
