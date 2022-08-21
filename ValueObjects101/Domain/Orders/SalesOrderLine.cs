using ValueObjects101.Domain.Articles;

namespace ValueObjects101.Domain.Orders;

public class SalesOrderLine
{
    public int Id { get; private set; }
    public long OrderId { get; private set; }
    public long ArticleId { get; private set; }
    public int Quantity { get; private set; }

    public Article Article { get; private set; } = null!;

    public SalesOrderLine(int id, long orderId, long articleId, int quantity)
    {
        Id = id;
        OrderId = orderId;
        ArticleId = articleId;
        Quantity = quantity;
    }

    private SalesOrderLine()
    {
    }
}
