using ValueObjects101.Domain.Shared.Exceptions;

namespace ValueObjects101.Domain.Shared.ValueObjects;

public class Email : IEquatable<Email>
{
    private readonly string _value;

    public Email(string? value)
    {
        if (!IsValid(value))
            throw new InvalidEmailException(value);

        _value = value!;
    }

    public static bool IsValid(string? value)
    {
        return !string.IsNullOrWhiteSpace(value) && value.Length >= 5 && value.Contains('@');
    }

    public bool Equals(Email? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Email)obj);
    }

    public override int GetHashCode() => _value.GetHashCode();

    public static bool operator ==(Email left, Email right) => Equals(left, right);

    public static bool operator !=(Email left, Email right) => !Equals(left, right);

    public static implicit operator string(Email email) => email._value;
}
