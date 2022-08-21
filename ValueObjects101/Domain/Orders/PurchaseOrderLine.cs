using ValueObjects101.Domain.Articles;

namespace ValueObjects101.Domain.Orders;

public class PurchaseOrderLine
{
    public int Id { get; private set; }
    public long OrderId { get; private set; }
    public Article Article { get; private set; } = null!;
    public int Quantity { get; private set; }

    public PurchaseOrderLine(long orderId, Article article, int quantity)
    {
        OrderId = orderId;
        Article = article;
        Quantity = quantity;
    }

    private PurchaseOrderLine()
    {
    }
}
