using ValueObjects101.Domain.Shared.Exceptions;

namespace ValueObjects101.Application.Shared.Exceptions;

public class InvalidEmailException : ValueObjects101Exception
{
    public InvalidEmailException(string? email)
        : base($"Invalid email '{email}'")
    {
    }
}
