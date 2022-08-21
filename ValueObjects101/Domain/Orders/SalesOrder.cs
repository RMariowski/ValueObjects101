using ValueObjects101.Domain.Shared.ValueObjects;

namespace ValueObjects101.Domain.Orders;

public class SalesOrder
{
    public long Id { get; private set; }
    public ICollection<SalesOrderLine> Lines { get; private set; } = null!;
    public Email CustomerEmail { get; private set; } = null!;
    public string CustomerNote { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public Email CreatedBy { get; private set; } = null!;

    public SalesOrder(Email customerEmail, string customerNote, Email createdBy)
    {
        CustomerEmail = customerEmail;
        CustomerNote = customerNote;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    private SalesOrder()
    {
    }
}
