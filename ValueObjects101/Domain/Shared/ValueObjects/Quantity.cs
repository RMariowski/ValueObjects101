using ValueObjects101.Domain.Shared.Exceptions;

namespace ValueObjects101.Domain.Shared.ValueObjects;

/**
 * NOTE: Creating 'Value' property without 'init' prevents from using 'with' keyword which can omits validation:
 * public int Value { get; init; }
 * Quantity quantity = new(1);
 * var invalidQuantity = quantity with { Value = 0 }; 
 */
public record Quantity(int Value)
{
    public int Value { get; } = IsValid(Value) ? Value : throw new InvalidQuantityException(Value);

    public static bool IsValid(int value)
    {
        return value > 0;
    }
    
    public static implicit operator int(Quantity quantity) => quantity.Value;
}
