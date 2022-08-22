namespace ValueObjects101.Domain.Orders;

public class SalesOrder
{
    public long Id { get; private set; }
    public ICollection<SalesOrderLine> Lines { get; private set; } = null!;
    public string ContactEmail { get; private set; } = string.Empty;
    public string CustomerNote { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public string CreatedBy { get; private set; } = string.Empty;

    public SalesOrder(string contactEmail, string customerNote, string createdBy)
    {
        ContactEmail = contactEmail;
        CustomerNote = customerNote;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    private SalesOrder()
    {
    }
}
