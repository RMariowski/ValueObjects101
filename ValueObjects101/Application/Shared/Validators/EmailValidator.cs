using ValueObjects101.Application.Shared.Exceptions;

namespace ValueObjects101.Application.Shared.Validators;

public static class EmailValidator
{
    public static bool IsValid(string? email)
    {
        return !string.IsNullOrWhiteSpace(email) && email.Length >= 5 && email.Contains('@');
    }

    public static void ThrowIfInvalid(string? email)
    {
        if (!IsValid(email))
            throw new InvalidEmailException(email);
    }
}
