using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValueObjects101.Domain.Shared.ValueObjects;

namespace ValueObjects101.Infrastructure.Database.Converters;

public class QuantityConverter : ValueConverter<Quantity, double>
{
    public QuantityConverter()
        : base(quantity => quantity.Value, value => new Quantity(value))
    {
    }
}
