using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValueObjects101.Domain.Shared.ValueObjects;

namespace ValueObjects101.Infrastructure.Database.Converters;

public class EmailConverter : ValueConverter<Email, string>
{
    public EmailConverter()
        : base(email => email, value => new Email(value))
    {
    }
}
