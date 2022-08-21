namespace ValueObjects101.Domain.Orders;

public class PurchaseOrder
{
    public long Id { get; private set; }
    public ICollection<PurchaseOrderLine> Lines { get; private set; } = null!;
    public string ContactEmail { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public string CreatedBy { get; private set; } = string.Empty;

    public PurchaseOrder(string contactEmail, string createdBy)
    {
        ContactEmail = contactEmail;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    private PurchaseOrder()
    {
    }
}
