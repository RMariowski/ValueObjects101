using ValueObjects101.Domain.Shared.Exceptions;

namespace ValueObjects101.Application.Orders.Exceptions;

public class PurchaseOrderNotFoundException : ValueObjects101Exception
{
    public PurchaseOrderNotFoundException(long id)
        : base($"Purchase order with id '{id}' not found")
    {
    }
}
