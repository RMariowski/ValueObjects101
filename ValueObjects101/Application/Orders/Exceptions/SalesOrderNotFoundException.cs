using ValueObjects101.Domain.Shared.Exceptions;

namespace ValueObjects101.Application.Orders.Exceptions;

public class SalesOrderNotFoundException : ValueObjects101Exception
{
    public SalesOrderNotFoundException(long id)
        : base($"Sales order with id '{id}' not found")
    {
    }
}