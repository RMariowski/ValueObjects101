using ValueObjects101.Domain.Shared.ValueObjects;

namespace ValueObjects101.Domain.Orders;

public class PurchaseOrder
{
    public long Id { get; private set; }
    public ICollection<PurchaseOrderLine> Lines { get; private set; } = null!;
    public Email ContactEmail { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public Email CreatedBy { get; private set; } = null!;

    public PurchaseOrder(Email contactEmail, Email createdBy)
    {
        ContactEmail = contactEmail;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    private PurchaseOrder()
    {
    }
}
