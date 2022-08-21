namespace ValueObjects101.Domain.Shared.Exceptions;

public abstract class ValueObjects101Exception : Exception
{
    public string Code { get; }

    protected ValueObjects101Exception(string message, string code = "")
        : base(message)
    {
        Code = string.IsNullOrWhiteSpace(code)
            ? GetType().Name.Replace("Exception", string.Empty)
            : code;
    }
}
